import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { AdminService } from 'src/app/shared/admin.service';
import { IUserId } from 'src/app/shared/interfaces';
import { LoadingService } from 'src/app/shared/loading.service';
import { ConfirmDialogComponent } from '../confirm-dialog/confirm-dialog.component';

@Component({
  selector: 'app-user-details-dialog',
  templateUrl: './user-details-dialog.component.html',
  styleUrls: ['./user-details-dialog.component.css']
})
export class UserDetailsDialogComponent implements OnInit {
  User: any;
  Role: string;
  Orders;
  currentPage = 0;
  isMailFieldOpen = false;
  mailData: FormGroup;
  reviews;
  IsBanned:boolean;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: { UserId: string },
    private _adminService: AdminService,
    private _toastr: ToastrService,
    private _loading: LoadingService,
    private _formBuilder: FormBuilder,
    private _dialog: MatDialog) {

    this._loading.isLoading(true);

    this.RefreshUserDetails();

    this.mailData = this._formBuilder.group({
      Title: ['', [Validators.required]],
      Body: ['', [Validators.required]]
    });
  }

  ngOnInit(): void {
  }


  RefreshUserDetails(){
    this._adminService.DetailedUser(this.data.UserId).subscribe(
      (res: any) => {
        this._loading.isLoading(false);
        this.User = res.User;
        this.Role = res.Role;
        this.Orders = res.Orders;
        this.IsBanned = res.IsBanned;
      },
      err => {
        this._loading.isLoading(false);
        this._toastr.error('Couldn\'t load user details.', 'Error');
        console.warn(err);
      });

      this.GetUserReviews();
  }

  GetUserReviews(){
    this._adminService.GetUserReviews(this.data.UserId).subscribe(
      res => {
        this.reviews = res;
      },
      err => {
        this._toastr.error('Couldn\'t receive user reviews', 'Error');
        console.warn(err);
      });
  }

  DeleteReview(item){
    this._loading.isLoading(true);
    this._adminService.DeleteReview(item.OrderId).subscribe(
      res => {
        this._loading.isLoading(false);
        item.Deleted = true;
        this._toastr.success('The comment has been deleted', 'Success');
      },
      err => {
        this._loading.isLoading(false);
        this._toastr.error('Couldn\'t delete the review', 'Error');
        console.warn(err);
      }
    );
  }

  ResetPassword() {
    this._loading.isLoading(true);
    this._adminService.ResetUserPassword(this.data.UserId).subscribe(
      res => {
        this._loading.isLoading(false);
        this._toastr.success('User password resetted.', 'Success');
      },
      err => {
        this._loading.isLoading(false);
        this._toastr.error('Something went wrong while reseting the password.', 'Error');
        console.warn(err);
      });
  }

  SendEmail() {
    if (this.mailData.valid) {
      const model = {
        UserId: this.data.UserId,
        Title: this.mailData.get('Title').value,
        Body: this.mailData.get('Body').value
      };
      this.isMailFieldOpen = false;

      this._adminService.SendMail(model).subscribe(
        res => {
          this._toastr.success('Email is sent', 'Success');
          this.mailData.reset();
        },
        err => {
          this._toastr.error('Couldn\t send the email.', 'Error');
          this.isMailFieldOpen = true;
          console.warn(err);
        }
      );

    } else {
      this._toastr.error('Can\'t contain empty fields.', 'Error');
    }
  }

  ToggleMailField() {
    this.isMailFieldOpen = !this.isMailFieldOpen;
  }

  getTotal(details: any[]) {
    let total = 0;
    details.forEach(element => {
      total += (element.ProductPrice * element.Quantity);
    });
    return total;
  }


  arrayEmpty(array: any[]){
    return !Array.isArray(array) || !array.length;
  }

  confirmEmail() {
    this._adminService.ConfirmEmail(this.User.Id).subscribe(
      res => {
        this._toastr.success('Confirmed email', 'Success');
        this.User.EmailConfirmed = true;
      },
      err => {
        this._toastr.error('Could\'t confirm email.', 'Error');
        console.warn(err);
      });
  }

  confirmPhoneNumber() {
    this._adminService.ConfirmPhoneNumber(this.User.Id).subscribe(
      res => {
        this._toastr.success('Confirmed phone number', 'Success');
        this.User.PhoneNumberConfirmed = true;
      },
      err => {
        this._toastr.error('Could\'t confirm phone number.', 'Error');
        console.warn(err);
      });
  }



  NextPage(){
    this.currentPage ++;

    if(this.currentPage * 3 > this.Orders.length){
      this.currentPage--;
      this._toastr.info('End of the list...', 'Can\'t do that.')
    }
    //this.updateOrderHistory();
  }

  PreviousPage(){
    if(this.currentPage > 0){
      this.currentPage --;
      //this.updateOrderHistory();
    }else {
      this._toastr.info("Already at first page...", 'Can\'t do that.');
    }
  }

  openBanUser(){
    const dialogRef = this._dialog.open(ConfirmDialogComponent, {
      data: {
        Title: "Are you sure you want to ban this user?",
        Body: "The user '" + this.User.FirstName + " " + this.User.LastName + "' will get banned.",
        Action: "Ban"
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result == true) {
        this._loading.isLoading(true);
        this._adminService.BanUser(this.User.Id).subscribe(
          res => {
            this._loading.isLoading(false);
            this._toastr.success('User has been banned.', 'Success');
            this.IsBanned = true;
            this.RefreshUserDetails();
          },
          err => {
            this._loading.isLoading(false);
            this._toastr.error(err?.error?.message ? err?.error?.message : 'Couldnt ban the user', 'Error', {
              timeOut: 5000
            });

          }
        );
      }
    });
  }



  openUnbanUser(){
    const dialogRef = this._dialog.open(ConfirmDialogComponent, {
      data: {
        Title: "Are you sure you want to unban this user?",
        Body: "The user '" + this.User.FirstName + " " + this.User.LastName + "' will get unbanned.",
        Action: "Unban"
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result == true) {
        this._loading.isLoading(true);
        this._adminService.UnbanUser(this.User.Id).subscribe(
          res => {
            this._loading.isLoading(false);
            this._toastr.success('User has been unbanned.', 'Success');
            this.IsBanned = false;
          },
          err => {
            this._loading.isLoading(false);
            this._toastr.error(err?.error?.message ? err?.error?.message : 'Couldnt unban the user', 'Error', {
              timeOut: 5000
            });

          }
        );
      }
    });
  }
}
