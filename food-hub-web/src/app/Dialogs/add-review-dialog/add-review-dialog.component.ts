import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { ApplicationUserService } from 'src/app/shared/application-user.service';
import { IPostReviewAndComment } from 'src/app/shared/interfaces';
import { LoadingService } from 'src/app/shared/loading.service';

@Component({
  selector: 'app-add-review-dialog',
  templateUrl: './add-review-dialog.component.html',
  styleUrls: ['./add-review-dialog.component.css']
})
export class AddReviewDialogComponent implements OnInit {

  formData: FormGroup;
  rating

  constructor(
    @Inject(MAT_DIALOG_DATA) private data: any,
    private _formBuilder: FormBuilder,
    private _userService: ApplicationUserService,
    private _toastr: ToastrService,
    private _loading: LoadingService,
    private dialogRef: MatDialogRef<AddReviewDialogComponent>
  ) {

    this.formData = this._formBuilder.group({
      comment: ['',[Validators.maxLength(200)]]
    });
  }

  ngOnInit(): void {
  }

  PostReview() {
    this._loading.isLoading(true);
    var review: IPostReviewAndComment = {
      OrderId: this.data.order.OrderId,
      Rating: parseInt(this.rating),
      Comment: this.formData.value.comment
    }

    if (!this.rating) {
      this._toastr.error('Cant post a review without picking a rating', 'Error');
      this._loading.isLoading(false);
      return;
    }
    this._userService.PostReviewAndComment(review).subscribe(
      res => {
        this._loading.isLoading(false);
        this._toastr.success('Rating posted', 'Success');
        this.dialogRef.close(true);
      },
      err => {
        this._loading.isLoading(false);
        if (err.error?.message) {
          this._toastr.error('Couldn\'t post the rating. ' + err.error.message, 'Error');
        } else {
          this._toastr.error('Couldn\'t post the rating', 'Error');
        }

        console.log(err);
      }
    );
  }

}
