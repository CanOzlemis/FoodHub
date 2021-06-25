import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ApplicationUserService } from 'src/app/shared/application-user.service';
import { ICart } from 'src/app/shared/interfaces';
import { LoadingService } from 'src/app/shared/loading.service';

@Component({
  selector: 'app-send-order-dialog',
  templateUrl: './send-order-dialog.component.html',
  styleUrls: ['./send-order-dialog.component.css']
})
export class SendOrderDialogComponent implements OnInit {

  orderInfoForm: FormGroup;
  address;
  cartItems: ICart[];
  total: number = 0;

  constructor(
    private _formBuilder: FormBuilder,
    private _userService: ApplicationUserService,
    private _toastr: ToastrService,
    private _loading: LoadingService,
  ) { 
    this.initialiseForm();
    this._userService.GetAddress().subscribe(
      (res: any) => {
        this.address = res.address;
        this.patchAddressValue();
      },
      err => {
        this._toastr.warning('Could\'t get address. Please write your address manually', 'Failed.');
      });
    
      this.updateCart();
  }

  ngOnInit(): void {
  }

  initialiseForm(){
    this.orderInfoForm = this._formBuilder.group({
      note: ['', [Validators.maxLength(200)]],
      address: [this.address, [Validators.required, Validators.maxLength(300)]]
    });

  }

  patchAddressValue() {
    this.orderInfoForm.get('address').setValue(this.address);
  }

  returnValue(){
    return [this.orderInfoForm.get('note').value, this.orderInfoForm.get('address').value];
  }


  updateCart() {
    this._loading.isLoading(true);
    this.total = 0;
    this.cartItems = JSON.parse(localStorage.getItem('cart'));

    if (this.cartItems) {
      this.cartItems.forEach((element: ICart) => {
        this.total += element.ProductPrice * element.Quantity;
      });

      if (this.cartItems.length == 0) {
        this.cartItems = null;
      }
    }
    this._loading.isLoading(false);
  }

}
