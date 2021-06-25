import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ApplicationUserService } from 'src/app/shared/application-user.service';

@Component({
  selector: 'app-edit-profile-dialog',
  templateUrl: './edit-profile-dialog.component.html',
  styleUrls: ['./edit-profile-dialog.component.css']
})
export class EditProfileDialogComponent implements OnInit {

  editProfileForm: FormGroup;
  address;

  constructor(
    private _formBuilder: FormBuilder,
    private _userService: ApplicationUserService,
    private _toastr: ToastrService
  ) { 
    this._userService.GetAddress().subscribe(
      (res: any) => {
        this.address = res.address;
        this.buildForm();
      },
      err => {
        this._toastr.error('Could\'t get address information', 'Failed.');
        this.buildForm();
      });

  }

  buildForm(){
    this.editProfileForm = this._formBuilder.group({
      address: [this.address, [Validators.maxLength(300)]]
    });
  }

  ngOnInit(): void {
  }

}
