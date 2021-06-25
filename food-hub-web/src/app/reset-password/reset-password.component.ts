import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ApplicationUserService } from '../shared/application-user.service';
import { IResetPassword } from '../shared/interfaces';
import { LoadingService } from '../shared/loading.service';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.css']
})
export class ResetPasswordComponent implements OnInit {

  Id: string;
  Hash: string;
  NewPasswordForm: FormGroup;

  constructor( 
    private _route: ActivatedRoute, 
    private _toastr: ToastrService, 
    private _user: ApplicationUserService,
    private _router: Router,
    private _loading: LoadingService,
    private formBuilder: FormBuilder) { }


  ngOnInit(): void {
    localStorage.clear(); // Logout if someone is already logged in

    this._loading.isLoading(true);

    this.NewPasswordForm = this.formBuilder.group({
      NewPassword: ['', [
        Validators.required,
        Validators.minLength(6),
      ]],
      PasswordMatch: ['', [
        Validators.required,
        Validators.minLength(6)
      ]]
    });

    this._route.queryParamMap.subscribe((params : any) => {
      this.Id = params?.params?.id as string;
      this.Hash = params?.params?.hash as string;

      if(this.Id == null && this.Hash == null){
        this._toastr.error('Invalid link!', 'Error');
        this._router.navigateByUrl("/login");
      }else {

        let tempHashChars:any = [];
        for(let i = 0; i < this.Hash.length; i++){ // Hash fix, when the hash contains '+' the url converts it to '%20' which when reading converts to empty space
          tempHashChars[i] = this.Hash[i] == ' ' ? '+': this.Hash[i];
        }
  
        this.Hash = tempHashChars.join('');
        this._loading.isLoading(false);
      }
    });
    this._loading.isLoading(false);
  }

  ResetPassword(){
    if(this.NewPasswordForm.valid && this.isMatching()){

      const model :IResetPassword = {UserId: this.Id, Hash: this.Hash, NewPassword: this.NewPasswordForm.get('NewPassword').value};
      this._user.ResetPassword(model).subscribe(
        res => {
          this._loading.isLoading(false);
          this._toastr.success('Password has been resetted', 'Success');
          this._router.navigateByUrl("/login");
        },
        err => {
          this._loading.isLoading(false);
          this._toastr.error( err?.error?.message ? err.error.message : 'Password could not be resetted', 'Could not reset password', {timeOut: 7000});
          console.log(err);
        });
    }else {
      this._toastr.error('Does not meet requirements!', 'Error');
    }
  }

  
  isMatching(){
    const pass = this.NewPasswordForm.get('NewPassword').value;
    const repPass = this.NewPasswordForm.get('PasswordMatch').value;
    if(pass && pass.trim() && repPass && repPass.trim()){
      return pass == repPass;
    }
    return false;
  }

  


}
