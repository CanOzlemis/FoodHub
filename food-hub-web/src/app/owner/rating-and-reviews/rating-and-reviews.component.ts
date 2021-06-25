import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { AddResponseComponent } from 'src/app/Dialogs/add-response/add-response.component';
import { ConfirmDialogComponent } from 'src/app/Dialogs/confirm-dialog/confirm-dialog.component';
import { IId } from 'src/app/shared/interfaces';
import { LoadingService } from 'src/app/shared/loading.service';
import { OwnerService } from 'src/app/shared/owner.service';

@Component({
  selector: 'app-rating-and-reviews',
  templateUrl: './rating-and-reviews.component.html',
  styleUrls: ['./rating-and-reviews.component.css']
})
export class RatingAndReviewsComponent implements OnInit {

  ReviewAndComments;

  constructor(
    private _ownerService: OwnerService,
    private _toastr: ToastrService,
    private _dialog: MatDialog,
    private _loading: LoadingService
  ) { }

  ngOnInit(): void {
    this.UpdateReviewAndComents();
  }

  UpdateReviewAndComents() {
    this._loading.isLoading(true);
    this._ownerService.GetReviewAndResponses().subscribe(
      (res: any) => {
        this._loading.isLoading(false);
        this.ReviewAndComments = res as [];
      },
      err => {
        this._loading.isLoading(false);
        this._toastr.error('Couldnt load review and ratings.', 'Error');
      }
    );
  }



  OpenResponseDialog(model) {
    const dialogRef = this._dialog.open(AddResponseComponent, {
      data: {
        model: model
      }
    });


    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.UpdateReviewAndComents();
      }
    });
  }

  OpenDeleteDialog(id) {
    const dialogRef = this._dialog.open(ConfirmDialogComponent, {
      data: {
        Title: "Are you sure you want to delete this review?",
        Body: "This action can't be reversed. The comment and (if exists) your response will be deleted but the rating will be kept.",
        Action: "Delete"
      }
    });

    const model: IId = {Id: id};
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this._ownerService.DeleteComment(model).subscribe(
          res => {
            this._toastr.info('Comment deleted.');
            this.UpdateReviewAndComents();
          },
          err => {
            this._toastr.error('Something went wrong while deleting the comment');
          });

        
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


  arrayEmpty(array: any[]){
    return !Array.isArray(array) || !array.length;
  }

}
