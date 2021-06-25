import { Component, Inject, OnInit } from '@angular/core';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { IFeedback } from 'src/app/shared/interfaces';
import { UserDetailsDialogComponent } from '../user-details-dialog/user-details-dialog.component';

@Component({
  selector: 'app-feedback-details-dialog',
  templateUrl: './feedback-details-dialog.component.html',
  styleUrls: ['./feedback-details-dialog.component.css']
})
export class FeedbackDetailsDialogComponent implements OnInit {

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: IFeedback,
    private _dialog: MatDialog
  ) { }

  ngOnInit(): void {
  }


  openUser(userId: string){
    let dialogRef = this._dialog.open(UserDetailsDialogComponent, {
      data: { UserId: userId }
    });
  }

}
