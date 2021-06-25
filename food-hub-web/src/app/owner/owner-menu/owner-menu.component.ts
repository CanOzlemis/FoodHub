import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ToastrService } from 'ngx-toastr';
import { ConfirmDialogComponent } from 'src/app/Dialogs/confirm-dialog/confirm-dialog.component';
import { EditMenuItemDialogComponent } from 'src/app/Dialogs/edit-menu-item-dialog/edit-menu-item-dialog.component';
import { IMenuItem } from 'src/app/shared/interfaces';
import { LoadingService } from 'src/app/shared/loading.service';
import { OwnerService } from 'src/app/shared/owner.service';

@Component({
  selector: 'app-owner-menu',
  templateUrl: './owner-menu.component.html',
  styleUrls: ['./owner-menu.component.css']
})
export class OwnerMenuComponent implements OnInit {

  menu;
  dataSource;
  newMenuItem: FormGroup;
  @ViewChild(MatSort) sort: MatSort;

  constructor(
    private _formBuilder: FormBuilder,
    private _ownerService: OwnerService,
    private _toastr: ToastrService,
    private _loading: LoadingService,
    public _dialog: MatDialog
  ) { }

  ngOnInit(): void {

    this.updateMenu();

    this.newMenuItem = this._formBuilder.group({
      category: ['Food', [Validators.required, Validators.maxLength(25)]],
      name: ['', [Validators.required, Validators.maxLength(50)]],
      about: ['', [Validators.maxLength(200)]],
      price: ['', [Validators.required, Validators.min(0), Validators.max(999)]]
    });
  }


  updateMenu() {
    this._loading.isLoading(true);
    this._ownerService.GetMenuList().subscribe(
      (res: any) => {
        this._loading.isLoading(false);
        this.dataSource = new MatTableDataSource(res);
        this.dataSource.sort = this.sort;
      },
      err => {
        this._loading.isLoading(false);
        this._toastr.error('An error occured while loading menu', 'Error', {
          timeOut: 5000
        });
      }
    )
  }


  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }


  addNewItemToMenu() {
    this._loading.isLoading(true);
    if (!this.newMenuItem.valid) {
      this._loading.isLoading(false);
      return;
    }


    //If the input is like 5.13513843 convert it to 5.13 and delete the rest.
    this.newMenuItem.get('price').setValue(parseFloat((this.newMenuItem.get('price').value as number).toFixed(2)));

    this._ownerService.PostItemToMenu(this.newMenuItem.value).subscribe(
      res => {
        this._loading.isLoading(false);
        this._toastr.success('Item added to the menu.', 'Success');
        this.updateMenu();
        this.newMenuItem.reset();
      },
      err => {
        this._loading.isLoading(false);
        this._toastr.error(err.error?.message ? err.error?.message : 'An error acured while adding item to the menu', 'Error', {
          timeOut: 5000
        });
      }
    )
  }


  EditMenuItem(model: IMenuItem) {
    const dialogRef = this._dialog.open(EditMenuItemDialogComponent, {
      data: {
        model: model
      }
    });


    dialogRef.afterClosed().subscribe(result => {

      if (result) {
        this._loading.isLoading(true);
        //If the input is like 5.13513843 convert it to 5.13 and delete the rest.
        result.price = parseFloat((result.price as number).toFixed(2));
        this._ownerService.UpdateMenuItem(result).subscribe(
          res => {
            this._loading.isLoading(false);
            this._toastr.success('Item updated successfuly.', 'Success');
            this.updateMenu();
          },
          err => {
            this._loading.isLoading(false);
            console.warn(err);
            this._toastr.error( err?.error ? err.error : 'Couldn\'t update item from menu', 'Error', {
              timeOut: 5000
            });

          }
        );
      }

    });
  }

  DeleteMenuItem(id: number) {

    const dialogRef = this._dialog.open(ConfirmDialogComponent, {
      data: {
        Title: "Are you sure you want to delete this item?",
        Body: "This action can't be reversed",
        Action: "Delete"
      }
    });

    dialogRef.afterClosed().subscribe(result => {

      if (result == true) {
        this._loading.isLoading(true);
        this._ownerService.DeleteMenuItem(id).subscribe(
          res => {
            this._loading.isLoading(false);
            this._toastr.success('Item deleted successfuly.', 'Success');
            this.updateMenu();
          },
          err => {
            this._loading.isLoading(false);
            this._toastr.error('Couldnt delete item from menu', 'Error', {
              timeOut: 5000
            });

          }
        );
      }
    });
  }

}
