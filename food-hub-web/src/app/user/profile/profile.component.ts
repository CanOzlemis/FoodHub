import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { faHeart, faMoneyBillAlt, faSmile } from '@fortawesome/free-regular-svg-icons';
import { faHeartbeat } from '@fortawesome/free-solid-svg-icons';
import { ToastrService } from 'ngx-toastr';
import { ChangePasswordDialogComponent } from 'src/app/Dialogs/change-password-dialog/change-password-dialog.component';
import { EditProfileDialogComponent } from 'src/app/Dialogs/edit-profile-dialog/edit-profile-dialog.component';
import { ApplicationUserService } from 'src/app/shared/application-user.service';
import { IUser } from 'src/app/shared/interfaces';
import { LoadingService } from 'src/app/shared/loading.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  IconEmptyHeart = faHeart;
  IconMoney = faMoneyBillAlt;
  IconSmile = faSmile;

  constructor(
    private _user: ApplicationUserService,
    private _toastr: ToastrService,
    private _loading: LoadingService,
    private _dialog: MatDialog) {

  }

  userData: IUser;
  totalNumberOfOrders: number;
  mostOrderRestaurant;
  highestRatingDataResult;
  highestOrder;
  recentOrder;
  restaurantDetail = null;
  favRestaurants;
  restaurantImages;


  ngOnInit(): void {
    this._loading.isLoading(true);
    this._user.userInfo().subscribe(
      (res: any) => {
        this._loading.isLoading(false);
        this.totalNumberOfOrders = res.numberOfOrders;
        this.highestRatingDataResult = res.highestRatingDataResult;
        this.highestOrder = res.highestOrderResult;
        this.mostOrderRestaurant = res.mostOrderRestaurantResult;
        this.recentOrder = res.recentOrderResult;
        this.favRestaurants = res.favRestaurants;
        //The images are on the same index as the favRestaurants so the first favRestaurants is equal to first restaurantImages
        this.restaurantImages = res.restaurantImages;

        this.userData = res.userResult as IUser;
      },
      err => {
        this._loading.isLoading(false);
        this._toastr.error('Something went wrong while receiving profile info', 'Error', {
          timeOut: 10000
        });
        console.warn(err);
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

  generateLinkParameter(name, id) {
    return (name + '!' + id);
  }

  arrayEmpty(array: any[]) {
    return !Array.isArray(array) || !array.length;
  }

  OpenProfileEditor() {
    const dialogRef = this._dialog.open(EditProfileDialogComponent);

    dialogRef.afterClosed().subscribe(result => {
      if (result !== false) {
        this._user.UpdateAddress(result).subscribe(
          res => {
            this._toastr.success('Address updated.', 'Success');
            this.userData.Address = result;
          },
          err => {
            this._toastr.error('Failed to update address', 'Failed');
            console.warn(err);
          }
        );
      }

    });
  }

  OpenChangePassword() {
    const dialogRef = this._dialog.open(ChangePasswordDialogComponent);

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        
      }

    });
  }


}
