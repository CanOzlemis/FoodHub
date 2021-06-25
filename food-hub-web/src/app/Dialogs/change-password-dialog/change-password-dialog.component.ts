import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { ApplicationUserService } from 'src/app/shared/application-user.service';

@Component({
  selector: 'app-change-password-dialog',
  templateUrl: './change-password-dialog.component.html',
  styleUrls: ['./change-password-dialog.component.css']
})
export class ChangePasswordDialogComponent implements OnInit {

  changePasswordForm: FormGroup;
  address;

  constructor(
    private _formBuilder: FormBuilder,
    private _userService: ApplicationUserService,
    private _toastr: ToastrService,
    public dialogRef: MatDialogRef<ChangePasswordDialogComponent>
  ) { 
    this.buildForm();
  }


  isMatching(){
    const pass = this.changePasswordForm.get('password').value;
    const repPass = this.changePasswordForm.get('repeatPassword').value;
    if(pass && pass.trim() && repPass && repPass.trim()){
      return pass == repPass;
    }
    return false;
  }

  buildForm(){
    this.changePasswordForm = this._formBuilder.group({
      password: ['', [Validators.minLength(6), Validators.required]],
      repeatPassword: ['', [Validators.minLength(6), Validators.required]]
    });
  }

  changePassword() {
    if(this.changePasswordForm.invalid){
      return;
    }

    this._userService.ChangePassword(this.changePasswordForm.get('password').value).subscribe(
      (res: any) => {
        this._toastr.success(res?.message ? res?.message : 'Password changed', 'Success');
        this.dialogRef.close();
      },
      err => {
        this._toastr.error(err?.error?.message ? err?.error?.message : 'Password change failed', 'Error');
        console.warn(err);
      }
    );



  }

  ngOnInit(): void {
  }

}
