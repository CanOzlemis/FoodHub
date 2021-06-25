import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { AdminService } from 'src/app/shared/admin.service';
import { IId } from 'src/app/shared/interfaces';
import { LoadingService } from 'src/app/shared/loading.service';


enum days {
  Monday,
  Thuesday,
  Wednesday,
  Thursday,
  Friday,
  Saturday,
  Sunday
}


@Component({
  selector: 'app-restaurant-details',
  templateUrl: './restaurant-details.component.html',
  styleUrls: ['./restaurant-details.component.css']
})
export class RestaurantDetailsComponent implements OnInit {

  CurrentEarnings;
  OwnerInfo;
  PreviousMonthsEarnings;
  RestaurantDetails;
  WorkingsTimes;
  Image;
  Happiness;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: { RestaurantId: number },
    private _adminService: AdminService,
    private _toastr: ToastrService,
    private _loading: LoadingService,
    private _formBuilder: FormBuilder
  ) 
  { 
    this._loading.isLoading(true);
    this.loadRestaurantDetails();
  }

  ngOnInit(): void {

  }

  loadRestaurantDetails(){
    
    this._adminService.GetRestaurantDetails(this.data.RestaurantId).subscribe(
      (res: any) => {
        this._loading.isLoading(false);
        this.CurrentEarnings = res.CurrentEarnings;
        this.OwnerInfo = res.OwnerInfo;
        this.PreviousMonthsEarnings = res.PreviousMonthsEarnings;
        this.RestaurantDetails = res.RestaurantDetails;
        this.WorkingsTimes = res.WorkingTimes;
        this.Image = res.Image ? 'data:image/jpeg;base64,' + res.Image : null;
        this.Happiness = res.Happiness;
      },
      err => {
        this._loading.isLoading(false);
        this._toastr.error('Can\'t load restaurant details', 'Error');
        console.warn(err);
      });

  }


  arrayEmpty(array: any[]){
    return !Array.isArray(array) || !array.length;
  }

  day(index) {
    return days[index];
  }

  enable(id: number){
    this._loading.isLoading(true);
    const model: IId = {Id: id};
    this._adminService.EnableRestaurant(model).subscribe(
      res => {
        this._loading.isLoading(false);
        this._toastr.info('Enabled.', 'Success');
        this.RestaurantDetails.Active = true;
      },
      err => {
        this._loading.isLoading(false);
        console.warn(err);
        this._toastr.error( err?.error?.message ? err.error.message  : 'Couldn\'t decline.', 'Error');
      });
  }

  disable(id: number){
    this._loading.isLoading(true);
    const model: IId = {Id: id};
    this._adminService.DisableRestaurant(model).subscribe(
      res => {
        this._loading.isLoading(false);
        this._toastr.info('Disabled.', 'Success');
        this.RestaurantDetails.Active = false;
      },
      err => {
        this._loading.isLoading(false);
        console.warn(err);
        this._toastr.error( err?.error?.message ? err.error.message  : 'Couldn\'t decline.', 'Error');
      });
  }

}
