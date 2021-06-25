import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { faFacebookF, faInstagram, faTwitter } from '@fortawesome/free-brands-svg-icons';
import { faClock, faHeart, faMoneyBillAlt, faStar } from '@fortawesome/free-regular-svg-icons';
import { faMoneyBill, faPhoneAlt } from '@fortawesome/free-solid-svg-icons';
import { ToastrService } from 'ngx-toastr';
import { ChatDialogComponent } from 'src/app/Dialogs/chat-dialog/chat-dialog.component';
import { ApplicationUserService } from 'src/app/shared/application-user.service';
import { IGetReviewAndComments, IId, IRestaurantDetail, IWorkingTime } from 'src/app/shared/interfaces';
import { LoadingService } from 'src/app/shared/loading.service';
import { RestaurantDetailService } from 'src/app/shared/restaurant-detail.service';
import { CartComponent } from '../cart/cart.component';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  restaurantId: number;
  restaurantDetails: IRestaurantDetail;
  ReviewAndComments: IGetReviewAndComments[];
  menu;
  categories: string[] = [];
  workingTime : IWorkingTime;
  isOpen = true;

  IconMoney = faMoneyBillAlt;
  IconClock = faClock;
  IconStar = faStar;
  IconFacebook = faFacebookF;
  IconInstagram = faInstagram;
  IconTwitter = faTwitter;
  IconPhone = faPhoneAlt;
  IconEmptyHeart = faHeart;

  @ViewChild(CartComponent) cart: CartComponent;

  constructor(
    private _restaurantDetailService: RestaurantDetailService,
    private _toastr: ToastrService,
    private _loading: LoadingService,
    private _route: ActivatedRoute,
    private _userService: ApplicationUserService,
    private _dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this._loading.isLoading(true);
    this._route.queryParams.subscribe(params => {
      this.restaurantId = parseInt(params['restId']);
      if (this.restaurantId) {

        // LOAD THE MENU
        this.LoadMenu();

        // LOAD THE RESTAURANT DETAILS
        this.LoadRestaurantDetails();

        // LOAD REVIEWS AND RATINGS
        this.LoadReviewsAndRatings();

      } else { // The link does not contain the restaurant parameter
        this._loading.isLoading(false);
        this._toastr.warning('Link is not correct.', 'Can\'t load menu', {
          timeOut: 10000
        });
      }
    });
  }

  LoadMenu() {
    this._loading.isLoading(true);
    this._restaurantDetailService.GetMenu(this.restaurantId).subscribe(
      res => {
        this.menu = res as [];

        this.menu.forEach((element: any) => { // Collect all categories in the categories array
          if (!this.categories.includes(element.Category as string)) {
            this.categories.push(element.Category as string)
          }
        });
        //The menu is loading too quick so the loading is not actually complete, need to mainly wait for this.LoadRestaurantDetails()
        this._loading.isLoading(false);
      },
      err => {
        this._loading.isLoading(false);
        if(err?.status == 404){

          this._toastr.error('The restaurant you are looking for could not be found.', 'Error', {
            timeOut: 10000
          });

        }else {
          this._toastr.error('Something went wrong while loading menu.', 'Error', {
            timeOut: 10000
          });
        }

      });
  }

  LoadRestaurantDetails() {
    
    this._loading.isLoading(true);
    this._restaurantDetailService.GetById(this.restaurantId).subscribe(
      (res: any) => {
        this._loading.isLoading(false);
        this.restaurantDetails = res.restaurantDetail as IRestaurantDetail;
        this.workingTime = res.workingTime as IWorkingTime;
        this.isOpen = res.isOpen;
      },
      err => {
        this._loading.isLoading(false);

        if(err?.status == 404){
          this._toastr.error('Could not find the details for the restaurant.', 'Error');
        }else {
          this._toastr.error('Could not load restaurant details.', 'Error');
        }

      });
  }

  LoadReviewsAndRatings() {
    this._restaurantDetailService.GetReviewAndComments(this.restaurantId).subscribe(
      res => {
        this.ReviewAndComments = res as [];
      },
      err => {
        if(err?.status == 404){
          this._toastr.error('Could not find the review and ratings for the restaurant.', 'Error');
        }else {
          this._toastr.error('Couldn\'t load review and ratings.', 'Error');
        }
      });
  }

  AddtoCart(item) {
    if(!this.isOpen){
      this._toastr.warning('The restaurant is currently closed. Please come back some other time.', 'This restaurant is closed', {timeOut: 5000});
      return;
    }

    let tempCart: any[] = JSON.parse(localStorage.getItem('cart'));
    let found: boolean = false;
    let isSameRestaurant = false;

    if (tempCart && tempCart.length > 0) { //If cart is not empty
      tempCart.forEach(element => {
        if (element.ProductId == item.Id) { //Increment the quantity
          element.Quantity = (++element.Quantity);
          found = true;
          this._toastr.info('Increased quantity of "' + element.ProductName + '" to ' + element.Quantity, 'Item quantity increased', {
            timeOut: 3000
          });
        }
      });

      if (found) { //Item exists in the cart
        localStorage.setItem('cart', JSON.stringify(tempCart));
      } else { // Push the new item to the cart
        if (tempCart[0].RestaurantId != this.restaurantId) {
          isSameRestaurant = true;
          this._toastr.error('Items from another restaurant already exists in the cart, please complete their process before continuing', 'Error', { timeOut: 10000 });
        } else {
          tempCart.push({
            RestaurantId: this.restaurantId,
            RestaurantName: this.restaurantDetails.Name,
            ProductId: item.Id,
            ProductName: item.Name,
            ProductPrice: item.Price,
            Quantity: 1
          });
        }
      }

    } else { // cart is empty, initialise 
      tempCart = [];
      tempCart.push({
        RestaurantId: this.restaurantId,
        RestaurantName: this.restaurantDetails.Name,
        ProductId: item.Id,
        ProductName: item.Name,
        ProductPrice: item.Price,
        Quantity: 1
      });
    }

    localStorage.setItem('cart', JSON.stringify(tempCart));
    const cart = JSON.parse(localStorage.getItem('cart'));


    if (!found && !isSameRestaurant) { //Info message is being displayed, dont dispaly this if found
      this._toastr.success('Number of items in cart ' + cart.length, 'Item added to the cart');
    }

    this.cart.updateCart();

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

  arrayEmpty(array: any[]) {
    return !Array.isArray(array) || !array.length;
  }


  toggleFavorite(id: number) {
    if (this._userService.isLoggedIn()) {
      this._userService.ToggleFavorite({ Id: id } as IId).subscribe(
        (res: any) => {
          this._toastr.info(res?.message ? res.message : "", 'Success!');
        },
        err => {
          this._toastr.error(err?.error?.message ? err.error.message : 'Something went wrong while adding to favorites...', 'Error');
          console.log(err);
        }
      );
    } else {
      this._toastr.warning('You need to be logged in to add restaurant to your favorites. ', 'Not logged in!');
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


  openMessage() {
    this._dialog.open(ChatDialogComponent, {
      data: {
        RestaurantId: this.restaurantId
      }
    });
  }


  isLoggedIn() {
    return this._userService.isLoggedIn();
  }

}
