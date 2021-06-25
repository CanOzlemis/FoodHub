import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { timeout } from 'rxjs/operators';
import { LoadingPageComponent } from '../loading-page/loading-page.component';
import { ApplicationUserService } from '../shared/application-user.service';
import { IResetPasswordMail } from '../shared/interfaces';
import { LoadingService } from '../shared/loading.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  hide : boolean = true;
  isLogin : boolean = true; //Used to toggle between forms
  inputWidth = 400;

  registerForm;
  loginForm;

  constructor(private formBuilder : FormBuilder,
              private _UserService: ApplicationUserService,
              private _loading : LoadingService,
              private _router : Router,
              private _toastr: ToastrService) { }

  ngOnInit(): void {

    if(this._UserService.isLoggedIn()){  // If the user is logged in
      this._router.navigateByUrl('');           // Return to main (home)
    }


    this.registerForm = this.formBuilder.group({
      firstName: ['', [
        Validators.required,
        Validators.maxLength(50)
      ]],
      lastName: ['', [
        Validators.required,
        Validators.maxLength(50)
      ]],
      email: ['', [
        Validators.required,
        Validators.email
      ]],
      phoneNumber: ['', [
        Validators.required,
        Validators.pattern("^[0-9]*$"),
        Validators.minLength(11),Validators.maxLength(11)
      ]],
      password: ['', [
        Validators.required,
        Validators.minLength(6)
      ]],
      repeatPassword: ['', [
        Validators.required,
        Validators.minLength(6)
      ]]
    });
  

  this.loginForm = this.formBuilder.group({
    email: ['', [
      Validators.required,
      Validators.email
    ]],
    password: ['', [
      Validators.required,
      Validators.minLength(6)
    ]]

  });
}

//#region RegisterForm Getters
  get firstName() {
    return this.registerForm.get('firstName');
  }

  get lastName() {
    return this.registerForm.get('lastName');
  }

  get email() {
    return this.registerForm.get('email');
  }

  get phoneNumber() {
    return this.registerForm.get('phoneNumber');
  }

  get password() {
    return this.registerForm.get('password');
  }

  get repeatPassword() {
    return this.registerForm.get('repeatPassword');
  }
//#endregion 

  toggleButton(){ //toggle between login form and register form
    this.isLogin = !this.isLogin;
  }

  isMatching(){
    const pass = this.password.value;
    const repPass = this.repeatPassword.value;
    if(pass && pass.trim() && repPass && repPass.trim()){
      return pass == repPass;
    }
    return false;
  }


  phoneNumberInputCheck(event: any) {
    const pattern = /[0-9\+\-\ ]/;
    let inputChar = String.fromCharCode(event.charCode);
    if (event.keyCode != 8 && !pattern.test(inputChar)) {
      event.preventDefault();
    }
  }

  LoginSubmit(loginForm) {

    this._loading.isLoading(true);
    

    const user = {
      Email : loginForm.value.email,
      Password : loginForm.value.password
    }

    this._UserService.Login(user).subscribe(
      (res:any) => {
        this._loading.isLoading(false);

        localStorage.clear(); // clearing the localStorage in case at one point the system did not delete it while logging out or token expired
        if(res){ //if the object is not empty the user has a confirmed mail
          this._toastr.success('Login success', 'Success', {
            timeOut: 1500
          });
          localStorage.setItem('token', res.token); //saving the token for authentication
          this._router.navigateByUrl(''); //Go to main page
        }else { // the user does not have a confirmed mail
          this._toastr.warning(
            'You must confirm your mail before proceeding, please check your email that you registered with. If you did not receive the email, <b>Click on this notification to re-send the email.</b>', 
            'Un-Confirmed Mail', 
            {timeOut: 10000}).onTap.subscribe((action) => this.ResendConfirmation(user.Email)); //When the user click on the notification, trigger the function
        }
      },
      err => {
        this._loading.isLoading(false);
        if(err.status == 400){
          this._toastr.error(err.error.message as string, 'Error', {
            timeOut: 5000,
            progressBar: true
          })
        }
        else {
          this._toastr.error('Unkown error, check console', 'Error')
          console.warn(err);
        }
      }
    );
  }

  RegistrationSubmit(registrationForm){
    this._loading.isLoading(true);
    if(!registrationForm.valid){
      this._loading.isLoading(false);
      this._toastr.error("Form you submitted is not valid", "Not a valid form");
      return;
    }

    this._UserService.RegisterUser(registrationForm.value).subscribe(
      (res:any) => {
        if(res.Succeeded){
          this._loading.isLoading(false);
          this._toastr.success('Succesfully registered!', 'Success');
          registrationForm.reset();
          this.isLogin = true; //Convert back to login page

        }else {
          if(res.Errors){ //If there are errors in the array
            res.Errors.forEach(error => {
              this._loading.isLoading(false);
              if (error.Code as string === 'DuplicateEmail'){ //If it is a duplicate email
                this._toastr.error(error.Description, 'Error', {
                  timeOut : 5000
                });
              }else if (error.Code as string === 'DuplicateUserName') {} //same as duplicate email so skip
              else {
                this._toastr.error(error.Description, 'Error', {
                  timeOut : 5000
                });
              }
            });
          } else {
            this._loading.isLoading(false);
            this._toastr.error( 'Unkown error. Check console', 'Error', {
              timeOut : 5000
            });
            console.warn(res);
          }
        }
        this._loading.isLoading(false);

      },
      err => {
        this._loading.isLoading(false);
        this._toastr.error(err?.error?.message ? err.error.message : 'Unkown error, check console', 'Error', {timeOut: 10000});
        console.warn(err);
      }
    )
  }

  ResetPassword() {
    this._loading.isLoading(true);
    if(this.loginForm.get('email').value && this.loginForm.get('email').valid) {

      const model: IResetPasswordMail = {Email: this.loginForm.get('email').value}

      this._UserService.ResetPasswordMail(model).subscribe(
        res => {
          this._toastr.success('If the email is registered in the system you will soon receive an email from us', 'Success', {timeOut: 10000});
          this._loading.isLoading(false);
        },
        err => {
          this._loading.isLoading(false);
          this._toastr.error('Something has gone wrong while sending email, email could not be sent', 'Error', {timeOut: 5000});
          console.log(err);
        });

    }else {
      this._loading.isLoading(false);
      this._toastr.info('Write your email in the email section to send the "reset password" link.', 'Email field is empty or not valid', {timeOut: 10000});
    }
  }

  ResendConfirmation(email: string) {
    this._UserService.ResendConfirmationMail(email).subscribe(
      (res:any) => {
        this._toastr.success(res?.message ? res?.message : 'Success, check your email', 'Success');
      },
      err => {
        this._toastr.error(err?.error?.message ? err.error.message : 'Unkown error, check console', 'Error', {timeOut: 10000});
      }
    );


  }


}
