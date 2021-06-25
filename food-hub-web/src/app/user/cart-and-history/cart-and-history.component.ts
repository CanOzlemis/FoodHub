import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { AddReviewDialogComponent } from 'src/app/Dialogs/add-review-dialog/add-review-dialog.component';
import { ApplicationUserService } from 'src/app/shared/application-user.service';
import { IGetOrderDetails, IGetOrders } from 'src/app/shared/interfaces';
import { LoadingService } from 'src/app/shared/loading.service';

@Component({
  selector: 'app-cart-and-history',
  templateUrl: './cart-and-history.component.html',
  styleUrls: ['./cart-and-history.component.css']
})
export class CartAndHistoryComponent implements OnInit, OnDestroy {

  orderHistory: IGetOrders[] = [];
  currentPage = 0;
  refresher;
  openedOrderId = -1;

  constructor(
    private _toastr: ToastrService,
    private _userService: ApplicationUserService,
    private _dialog: MatDialog,
    private _loading: LoadingService
  ) { }

  ngOnInit(): void {
    this._loading.isLoading(true);
    this.updateOrderHistory();

    this.refresher = setInterval(() => {
      this.updateOrderHistory();
      //this.UpdateChart(); // Refresh only if more orders are detected
    }, 6000); // repeat every 6 seconds
  }




ngOnDestroy(): void {
  /*
    * This has to be done to stop the loop from continuing none stop. Angular is a single page desing meaning that this page is 
    * never really closed hence we need to stop the interval once we are done with this component.
    */
  clearInterval(this.refresher);
}

  
  updateOrderHistory() {

    
    this._userService.GetOrderHisory(this.currentPage).subscribe(
      (res: any) => {
        this._loading.isLoading(false);
        this.orderHistory = res as IGetOrders[];

        if(this.arrayEmpty(this.orderHistory)){
          if(this.currentPage != 0){
            this.currentPage--;
            this._toastr.info('End of order history.', 'No data');
            this.updateOrderHistory();
          }
        }
      },
      err => {
        this._loading.isLoading(false);
        this._toastr.error('Couldn\'t get order history', 'Error');
        console.warn(err);
      });
  }

  NextPage(){
    this.currentPage ++;
    this.updateOrderHistory();
  }

  PreviousPage(){
    if(this.currentPage > 0){
      this.currentPage --;
      this.updateOrderHistory();
    }else {
      this._toastr.info("Already at first page...", 'Can\'t do that.');
    }
  }


  AddReview(model) {
    const dialogRef = this._dialog.open(AddReviewDialogComponent, {
      data: {
        order: model
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.updateOrderHistory();
      }
    });

  }

  
  getTotal(details: IGetOrderDetails[]) {
    let total = 0;
    details.forEach(element => {
      total += (element.ProductPrice * element.Quantity);
    });
    return total;
  }

  getProgressValue(status: string){
    return status === "Waiting" ? 33 : status === "Accepted" ? 66 : status === "Rejected" ? 0 : 100;
  }

  arrayEmpty(array: any[]){
    return !Array.isArray(array) || !array.length;
  }
}
