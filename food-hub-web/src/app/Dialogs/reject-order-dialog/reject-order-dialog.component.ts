import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-reject-order-dialog',
  templateUrl: './reject-order-dialog.component.html',
  styleUrls: ['./reject-order-dialog.component.css']
})
export class RejectOrderDialogComponent implements OnInit {

  formData: FormGroup;

  constructor(private _formBuilder: FormBuilder,) {
    this.formData = this._formBuilder.group({
      reason: ['', [Validators.required, Validators.maxLength(300)]]
    });
  }

  ngOnInit(): void {
  }

}
