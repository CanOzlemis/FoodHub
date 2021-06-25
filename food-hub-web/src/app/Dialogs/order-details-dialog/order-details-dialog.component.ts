import { Component, Inject, OnInit, ViewEncapsulation } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { IGetOrders } from 'src/app/shared/interfaces';
import { LoadingService } from 'src/app/shared/loading.service';
import { OwnerService } from 'src/app/shared/owner.service';

@Component({
  selector: 'app-order-details-dialog',
  templateUrl: './order-details-dialog.component.html',
  styleUrls: ['./order-details-dialog.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class OrderDetailsDialogComponent implements OnInit {

  Orders: IGetOrders;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    private _ownerService: OwnerService,
    private _toastr: ToastrService,
    private _loading: LoadingService
  ) { }

  ngOnInit(): void {
    this._loading.isLoading(true);
    this.Orders = this.data.model;
    this._loading.isLoading(false);
  }

  ConfirmPhoneNumber() {
    this._loading.isLoading(true);
    this._ownerService.ConfirmPhoneNumber(this.Orders.UserId).subscribe(
      res => {
        this._loading.isLoading(false);
        this._toastr.success('Confirmed the phone number', 'Success');
        this.Orders.PhoneNumberConfirmed = true;
      },
      err => {
        this._loading.isLoading(false);
        this._toastr.error(err.error?.message ? err.error.message : 'Couldn\'t confirm the number.', 'Error');
        console.log(err);
      }
    );
  }
}
