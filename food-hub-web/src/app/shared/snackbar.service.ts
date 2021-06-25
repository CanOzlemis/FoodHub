import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class SnackbarService {

  constructor(private _snackBar : MatSnackBar) { }

  openSnackbar(message, button) {
    this._snackBar.open(message, button, {
      duration: 3000,
    });
  }
}
