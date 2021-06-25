import { Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatTabChangeEvent } from '@angular/material/tabs';
import { faFacebookSquare, faInstagramSquare, faTwitterSquare } from '@fortawesome/free-brands-svg-icons';
import { faDizzy, faSmileBeam } from '@fortawesome/free-regular-svg-icons';
import { faFrown, faMeh, faMehBlank, faPhone} from '@fortawesome/free-solid-svg-icons';
import { ToastrService } from 'ngx-toastr';
import { ConfirmDialogComponent } from 'src/app/Dialogs/confirm-dialog/confirm-dialog.component';
import { OwnerEditDialogComponent } from 'src/app/Dialogs/owner-edit-dialog/owner-edit-dialog.component';
import { IRestaurantDetail, IWorkingTime } from 'src/app/shared/interfaces';
import { LoadingService } from 'src/app/shared/loading.service';
import { OwnerService } from 'src/app/shared/owner.service';
import { EconomicsComponent } from '../economics/economics.component';
import { OrdersComponent } from '../orders/orders.component';
import { RatingAndReviewsComponent } from '../rating-and-reviews/rating-and-reviews.component';



enum days {
  Monday,
  Thuesday,
  Wednesday,
  Thursday,
  Friday,
  Saturday,
  Sunday
}

interface IEditedRestaurantDetails {
  About: string,
  AverageDeliveryTime: number,
  MinOrderPrice: number
}

interface IEditedWorkingTimes {
  Day: number,
  OpenTime: string,
  CloseTime: string
}


@Component({
  selector: 'owner-main-menu',
  templateUrl: './main-menu.component.html',
  styleUrls: ['./main-menu.component.css']
})
export class OwnerMainMenuComponent implements OnInit {
  restaurantDetails: IRestaurantDetail;
  workingTimes: IWorkingTime[];
  editOwnerForm: FormGroup;
  selectedIndex: number;
  happiness: string;
  displayImage;
  orderCount = 0; //This data is updated via the app-orders child component to display the number of orders in queue

  @ViewChild('economics') economicsComp: EconomicsComponent; // using this to trigger functions inside the component
  @ViewChild('orders') ordersComp: OrdersComponent; // using this to trigger functions inside the component so that the chart can be rendered
  @ViewChild('ratings') ratingsComp: RatingAndReviewsComponent;

  IconFacebook = faFacebookSquare;
  IconInstagram = faInstagramSquare;
  IconTwitter = faTwitterSquare;
  IconPhone = faPhone;
  IconSmile = faSmileBeam;
  IconMeh = faMeh;
  IconFrown = faFrown;
  IconEmpty = faDizzy;
  constructor
    (
      private _ownerService: OwnerService,
      private _toastr: ToastrService,
      private _loading: LoadingService,
      private _dialog: MatDialog,
  ) {
  }


  ngOnInit() {
    this.UpdateThePage();
  }

  UpdateThePage() {
    this._loading.isLoading(true);
    this._ownerService.GetRestaurantDetails().subscribe(
      (res: any) => {
        this._loading.isLoading(false);
        this.restaurantDetails = res.restaurantDetail as IRestaurantDetail;
        this.workingTimes = res.workingTime as IWorkingTime[];
        this.happiness = res.happiness; // "Happy", "Satisfied", "Unhappy", "Empty"
        this.displayImage = res.Image ? 'data:image/jpeg;base64,' + res.Image : null;
      },
      err => {
        this._loading.isLoading(false);
        this._toastr.error("Could not load restaurant details.", "Error", {
          timeOut: 10000
        });
        console.warn(err);
      });


  }


  day(index) {
    return days[index];
  }

  openDialog() {
    const dialogRef = this._dialog.open(OwnerEditDialogComponent);

    dialogRef.afterClosed().subscribe((result: [IEditedRestaurantDetails, IEditedWorkingTimes[]]) => {
      if (result?.[0] != undefined) {
        this._loading.isLoading(true);

        const temp = {
          newRestaurantDetails: result[0] as IEditedRestaurantDetails,
          newWorkingTimes: result[1] as IEditedWorkingTimes[]
        }

        this._ownerService.UpdateRestaurantDetails(temp).subscribe(
          res => {
            this._toastr.success('Updated restaurant details', 'Success');
            this._loading.isLoading(false);
            this.UpdateThePage();
          },
          err => {
            this._toastr.error('Failed to update restaurant details', 'Error');
            this._loading.isLoading(false);
            console.warn(err);
          }
        );
      }

    });
  }

  storeRating(currentStarIterator, storeRating) {
    if (currentStarIterator <= storeRating) {
      return true;
    } else if ((currentStarIterator - 1 < storeRating) && storeRating % 1) {
      return false;
    }

  }

  halfOrEmptyStar(currentStarIterator, storeRating) {
    if ((currentStarIterator - 1 < storeRating) && storeRating % 1) {
      return true;
    } else {
      return false;
    }
  }
  

  onTabChanged(matTabEvent: MatTabChangeEvent) {

    if (matTabEvent.tab.textLabel === "Economics") { // Refresh the economics component with new data 
      this.economicsComp.ngOnInit();
    } else if (matTabEvent.tab.textLabel === "Orders"){
      this.ordersComp.UpdateChart();
    } else if (matTabEvent.tab.textLabel === "Reviews and comments"){
      this.ratingsComp.UpdateReviewAndComents();
    }

  }

  OpenLink(link: string, domain: string) {
    //Due to how angular works, the link must include "https" at beginning or angular will treat it as internal root.
    // This checks if it has "https" at start and adds it if there is not
    let url: string = '';
    if (!/^http[s]?:\/\//.test(link)) {
      url += 'http://';
    }


    url += domain + ".com/";
    url += link;
    window.open(url, '_blank');
  }

  disableRestaurant() {
    const dialogRef = this._dialog.open(ConfirmDialogComponent, {
      data: {
        Title: "Are you sure you want to disable the restaurant?",
        Body: "Doing so will REJECT ALL OF YOUR ORDERS, make your restaurant invisible to all the users and the restaurant can't be re-activated until you request it. Once the request is sent a admin needs to approve for the restaurant to be re-actived again.",
        Action: "Disable"
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this._ownerService.DisableRestaurant().subscribe(
          res => {
            this._toastr.success('Restaurant has been disabled.', 'Success');
            this.restaurantDetails.Active = false;
          },
          err => {
            this._toastr.error(err?.error?.message ? err.error.message : 'Could not disable the restaurant...', 'Failed');
            console.warn(err);
          });
      }

    });
  }

  requestEnableRestaurant() {
    this._ownerService.RequestRestaurantActivation().subscribe(
      res => {
        this._toastr.success('Admins have been informed. Your restaurant will be activated as soon as possible!', 'Success', {timeOut: 15000});
        this.restaurantDetails.ActivationRequest = true;
      },
      err => {
        this._toastr.error(err?.error?.message ? err.error.message : 'Could not request to activate the restaurant...', 'Failed');
        console.warn(err);
      });
  }




}
