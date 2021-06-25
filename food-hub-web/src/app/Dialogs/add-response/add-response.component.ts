import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { LoadingService } from 'src/app/shared/loading.service';
import { OwnerService } from 'src/app/shared/owner.service';

@Component({
  selector: 'app-add-response',
  templateUrl: './add-response.component.html',
  styleUrls: ['./add-response.component.css']
})
export class AddResponseComponent implements OnInit {

  formData: FormGroup;

  constructor(
    @Inject(MAT_DIALOG_DATA) private data: any,
    private _formBuilder: FormBuilder,
    private _ownerService: OwnerService,
    private _toastr: ToastrService,
    private _loading: LoadingService,
    private dialogRef: MatDialogRef<AddResponseComponent>
  ) { 
    this.formData = this._formBuilder.group({
      response: ['', [Validators.required]]
    });
  }

  ngOnInit(): void {
    
  }

  AddResponse() {
    this._loading.isLoading(true);
    const review = {
      OrderId: this.data.model.OrderId,
      Response: this.formData.value.response
    };

    if (!this.formData.valid) {
      this._toastr.error('Cant post a empty response', 'Error');
      this._loading.isLoading(false);
      return;
    }

    this._ownerService.AddResponse(review).subscribe(
      res => {
        this._loading.isLoading(false);
        this._toastr.success('Resonse posted', 'Success');
        this.dialogRef.close(true);
      },
      err => {
        this._loading.isLoading(false);
        if (err.error?.message) {
          this._toastr.error('Couldn\'t post the response. ' + err.error.message, 'Error');
        } else {
          this._toastr.error('Couldn\'t post the response', 'Error');
        }

        console.log(err);
      }
    );
  }


}
