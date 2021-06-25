import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { IConfirmDialog } from 'src/app/shared/interfaces';

@Component({
  selector: 'app-confirm-dialog',
  templateUrl: './confirm-dialog.component.html',
  styleUrls: ['./confirm-dialog.component.css']
})
export class ConfirmDialogComponent implements OnInit {

  checked=false;

  constructor(@Inject(MAT_DIALOG_DATA) public data: IConfirmDialog) { }

  ngOnInit(): void {
  }

}
