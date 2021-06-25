import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { SendOrderDialogComponent } from 'src/app/Dialogs/send-order-dialog/send-order-dialog.component';
import { ApplicationUserService } from 'src/app/shared/application-user.service';
import { ICart, IPostOrder, IPostOrderDetails } from 'src/app/shared/interfaces';
import { LoadingService } from 'src/app/shared/loading.service';
import { RestaurantDetailService } from 'src/app/shared/restaurant-detail.service';




@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})

export class CartComponent implements OnInit {

  cartItems: ICart[];
  Restaurants: string[] = [];
  total: number = 0;

  @Output() refreshHistory: EventEmitter<any> = new EventEmitter();
  @Input() minAmount: number = -1;


  constructor(
    private _toastr: ToastrService,
    private _userService: ApplicationUserService,
    private _dialog: MatDialog,
    private _loading: LoadingService,
    private _restaurantDetailService: RestaurantDetailService,
    private _router: Router
  ) { }

  ngOnInit(): void {
    this.updateCart();
  }

  updateCart() {
    this.total = 0;
    this.cartItems = JSON.parse(localStorage.getItem('cart'));

    if (this.cartItems) {
      this.cartItems.forEach((element: ICart) => { // Collect all categories in the categories array
        // if (!this.Restaurants.includes(element.RestaurantName as string)) {
        //   this.Restaurants.push(element.RestaurantName as string)
        // }

        this.total += element.ProductPrice * element.Quantity;
      });

      if (this.cartItems.length == 0) {
        this.cartItems = null;
      }
    }
  }


  clearCart() {
    localStorage.removeItem('cart');
    this.cartItems = null;
    this.Restaurants = [];
    this.total = 0;
    this._toastr.success('Cart cleared', 'Success');
  }

  Increment(id: number) {

    let tempCart: any[] = JSON.parse(localStorage.getItem('cart'));
    let found: boolean = false;

    tempCart.forEach(element => {
      if (element.ProductId == id) { //Increment the quantity
        element.Quantity = (++element.Quantity);
        found = true;
      }
    });

    if (found) { //Item exists in the cart
      localStorage.setItem('cart', JSON.stringify(tempCart));
      this.updateCart();
    }
  }

  Decrease(id: number) {
    let tempCart: any[] = JSON.parse(localStorage.getItem('cart'));
    let found: boolean = false;
    let skip: boolean = false;

    let i = 0;
    tempCart.forEach(element => {
      if (element.ProductId == id) { //Increment the quantity
        if (element.Quantity - 1 == 0) { //remove the item
          this.RemoveItem(-1, i);
          skip = true;
        }
        element.Quantity = (--element.Quantity);
        found = true;
      }
      i++;
    });
    if (found && !skip) { //Item exists in the cart
      localStorage.setItem('cart', JSON.stringify(tempCart));
      this.updateCart();
    }
  }

  RemoveItem(id: number, index?: number) {

    let tempCart: any[] = JSON.parse(localStorage.getItem('cart'));
    let removeItem: boolean = false;
    let removeItemAt: number = -1;

    if (index >= 0) { tempCart.splice(index, 1); }
    else {
      let i = 0;
      tempCart.forEach(element => {
        if (element.ProductId == id) { //Find the item
          removeItem = true;
          removeItemAt = i;
        }
        i++
      });

      if (removeItem) { tempCart.splice(removeItemAt, 1); }
    }

    localStorage.setItem('cart', JSON.stringify(tempCart));
    this.updateCart();

  }


  SendOrders(restId: number, address: string, note?: string) {

    this._loading.isLoading(true);

    let tempCart: any[] = JSON.parse(localStorage.getItem('cart'));

    if(this.minAmount == -1){ //Meaning the cart was not opened from menu and no min amount was set

      this._restaurantDetailService.GetById(tempCart[0].RestaurantId).subscribe(
        (res: any) => {
          if (res.restaurantDetail.MinOrderPrice as number > this.total) { //checking if the order matches the requirement of minimum order price
            this._loading.isLoading(false);
            this._toastr.error('The minimum order price is ' + res.restaurantDetail.MinOrderPrice + ' ₺.', 'Can\'t send order', {timeOut: 5000});
          } else {
            this.CompleteSendingOrder(restId, address, tempCart, note);
            
          }
        });
    } else {
      if(this.minAmount > this.total){

        this._toastr.error('The minimum order price is ' + this.minAmount + ' ₺.', 'Can\'t send order', {timeOut: 5000});
        return;
        
      }else {
        this.CompleteSendingOrder(restId, address, tempCart, note);
      }
    }


  }

  //This gets called by "SendOrders()" function, only if the requirements are met. (Had to do it like this to await subscribe cal)
  private CompleteSendingOrder(restId: number, address: string, tempCart: any[], note?: string) { 
    let details: IPostOrderDetails[] = [];

    tempCart.forEach((element: ICart) => {
      if (element.RestaurantId == restId) {
        let temp: IPostOrderDetails = {
          ProductId: element.ProductId,
          Quantity: element.Quantity
        };
        details.push(temp);
      }
    });

    const postOrder: IPostOrder = {
      RestaurantId: restId as number,
      Address: address,
      Note: note,
      Detail: details
    }

    this._userService.PostOrder(postOrder).subscribe(
      res => {
        this._loading.isLoading(false);
        this._toastr.success('Order sent successfuly', 'Success');
        localStorage.removeItem('cart'); //Clear out the cart
        this.updateCart();
        this.refreshHistory.emit(null);
      },
      err => {
        this._loading.isLoading(false);
        if (err.error?.message) {
          this._toastr.error(err.error.message, 'Error');
        } else {
          this._toastr.error('Couldn\'t send the order', 'Error');
        }

        console.warn(err);
      });
  }


  openDialog(id: number) {

    
    if(this.minAmount > this.total){
      this._toastr.warning('The minimum amount for sending order is ' + this.minAmount + ' ₺.', 'insufficient amount');
      return;
    }

    if(!localStorage.getItem('token')){ // The user is not signed up
      this._toastr.info('You need to login before you can send any orders.', 'You are not logged in', {timeOut: 7000});
      this._router.navigateByUrl("/login");
      return;
    }


    const dialogRef = this._dialog.open(SendOrderDialogComponent);

    //let numberId = parseInt(id); // even if the parameter is number, it comes as string. Must do it like this to convert to a number

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        // this.SendOrders(numberId, result[1], result[0]);
        this.SendOrders(id, result[1], result[0]);
      }
    });
  }

  //Old code used for finding the id of the restaurant from string to convert it to a number. This was being used when multiple restaurants could be added to cart

  // findIdFromString(name: string): number {

  //   let tempCart: any[] = JSON.parse(localStorage.getItem('cart'));
  //   let found = true;
  //   let result = -1;

  //   tempCart.forEach((element: ICart) => {
  //     found = true;

  //     for (let i = 0; i < element.RestaurantName.length; i++) {
  //       if (element.RestaurantName.length != name.length) {
  //         found = false;
  //         break;
  //       } else if (name.charCodeAt(i) != tempCart[0].RestaurantName.charCodeAt(i)) {
  //         found = false;
  //         break;
  //       }
  //     }
  //     if (found) {
  //       result = element.RestaurantId;
  //     }

  //   });
  //   return result;
  // }




}
