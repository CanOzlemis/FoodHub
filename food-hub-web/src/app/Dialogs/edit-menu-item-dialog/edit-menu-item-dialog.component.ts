import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { LoadingService } from 'src/app/shared/loading.service';

@Component({
  selector: 'app-edit-menu-item-dialog',
  templateUrl: './edit-menu-item-dialog.component.html',
  styleUrls: ['./edit-menu-item-dialog.component.css']
})
export class EditMenuItemDialogComponent implements OnInit {

  editedItem: FormGroup;

  constructor(
    private _formBuilder: FormBuilder,
    private _loading: LoadingService,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) { 
    this._loading.isLoading(true);
    this.initialiseForm();
    this._loading.isLoading(false);
  }

  ngOnInit(): void {
  }

  initialiseForm(){
    this.editedItem = this._formBuilder.group({
      category: [this.data.model.Category, [Validators.required, Validators.maxLength(25)]],
      name: [this.data.model.Name, [Validators.required, Validators.maxLength(50)]],
      about: [this.data.model.About, [Validators.maxLength(200)]],
      price: [this.data.model.Price, [Validators.required, Validators.min(0), Validators.max(999)]],
      id: [this.data.model.Id, [Validators.required]]
    });
  }

}
