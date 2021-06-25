import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ApplicationUserService } from '../shared/application-user.service';
import { IApplicantRestaurant } from '../shared/interfaces';
import { LoadingService } from '../shared/loading.service';

@Component({
  selector: 'app-partner-registration',
  templateUrl: './partner-registration.component.html',
  styleUrls: ['./partner-registration.component.css']
})
export class PartnerRegistrationComponent implements OnInit {

  form: FormGroup;

  constructor(
    private _route: ActivatedRoute, 
    private _toastr: ToastrService, 
    private _user: ApplicationUserService,
    private _router: Router,
    private _loading: LoadingService,
    private formBuilder: FormBuilder
  ) { }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      RestaurantName: ['', [
        Validators.required,
        Validators.minLength(1),
        Validators.maxLength(50)
      ]],
      RestaurantAddressCity: ['', [
        Validators.required,
        Validators.minLength(1),
      ]],
      RestaurantAddressStreet: ['', [
        Validators.required,
        Validators.minLength(1),
      ]],
      UserFirstName: ['', [
        Validators.required,
        Validators.minLength(1)
      ]],
      UserLastName: ['', [
        Validators.required,
        Validators.minLength(1)
      ]],
      UserEmail: ['', [
        Validators.required,
        Validators.minLength(2),
        Validators.email
      ]],
      UserPhoneNumber: ['', [
        Validators.pattern("^[0-9]*$"),
        Validators.minLength(11),
        Validators.maxLength(11),
        Validators.required
      ]]
    });
  }

  submitForm(){
    if(this.form.valid){
      this._loading.isLoading(true);

      const model: IApplicantRestaurant = {
        RestaurantName: this.form.get('RestaurantName').value,
        RestaurantCity: this.form.get('RestaurantAddressCity').value,
        RestaurantStreet: this.form.get('RestaurantAddressStreet').value,
        FirstName: this.form.get('UserFirstName').value,
        LastName: this.form.get('UserLastName').value,
        Email: this.form.get('UserEmail').value,
        PhoneNumber: this.form.get('UserPhoneNumber').value
      }

      this._user.AddApplicantRestaurant(model).subscribe(
        res => {
          this._loading.isLoading(false);
          this._toastr.success('Application submitted successfuly', 'Success');
          this.form.reset();
        },
        err => {
          this._loading.isLoading(false);
          this._toastr.error(err?.error?.message ? err?.error?.message : 'Could not submit the application', 'Error');
        }
      );
    }
  }

}
