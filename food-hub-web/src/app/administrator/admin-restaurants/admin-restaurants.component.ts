import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ToastrService } from 'ngx-toastr';
import { RestaurantDetailsComponent } from 'src/app/Dialogs/restaurant-details/restaurant-details.component';
import { AdminService } from 'src/app/shared/admin.service';
import { IApplicantDetails, IApplicantRestaurant, IId } from 'src/app/shared/interfaces';
import { LoadingService } from 'src/app/shared/loading.service';

@Component({
  selector: 'app-admin-restaurants',
  templateUrl: './admin-restaurants.component.html',
  styleUrls: ['./admin-restaurants.component.css']
})
export class AdminRestaurantsComponent implements OnInit {


  applicants: IApplicantDetails[] = [];

  displayedColumns = ['Id', 'Name', 'Rating', 'AverageDeliveryTime', 'MinOrderPrice', 'Active', 'City', 'Street', 'Actions'];
  data;
  total = 0;
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(
    private _adminService: AdminService,
    private _toastr: ToastrService,
    private _loading: LoadingService,
    private _dialog: MatDialog,
    private _formBuilder: FormBuilder
  ) { }

  ngOnInit(): void {
    this.updateRestaurantPage();
  }



  //Updated the entire data of the restaurants page
  updateRestaurantPage() {
    this._loading.isLoading(true);

    this._adminService.GetRestaurants().subscribe(
      (res: any) => {
        this._loading.isLoading(false);
        this.data = new MatTableDataSource(res);
        this.data.sort = this.sort;
        this.data.paginator = this.paginator;
      },
      err => {
        this._loading.isLoading(false);
        this._toastr.error('Couldn\'t load restaurants', 'Error');
        console.warn(err);
      }
    );

    this._adminService.GetApplicants().subscribe(
      res => {
        this.applicants = res as IApplicantDetails[];
      },
      err => {
        this._toastr.error('Could not load the applicants.', 'Error');
        console.warn(err);
      });

  }


  approve(id: number) {
    this._loading.isLoading(true);
    const model: IId = { Id: id };
    this._adminService.ApproveApplicant(model).subscribe(
      res => {
        this._loading.isLoading(false);
        this._toastr.success('Approved the applicant.', 'Success');
        this.updateRestaurantPage();
      },
      err => {
        this._loading.isLoading(false);
        console.warn(err);
        this._toastr.error(err?.error?.message ? err.error.message : 'Couldn\'t approve.', 'Error');
      });
  }

  decline(id: number) {
    this._loading.isLoading(true);
    const model: IId = { Id: id };
    this._adminService.DeclineApplicant(model).subscribe(
      res => {
        this._loading.isLoading(false);
        this._toastr.success('Declined the applicant.', 'Success');
        this.updateRestaurantPage();
      },
      err => {
        this._loading.isLoading(false);
        console.warn(err);
        this._toastr.error(err?.error?.message ? err.error.message : 'Couldn\'t decline.', 'Error');
      });
  }

  enable(id: number) {
    this._loading.isLoading(true);
    const model: IId = { Id: id };
    this._adminService.EnableRestaurant(model).subscribe(
      res => {
        this._loading.isLoading(false);
        this._toastr.info('Enabled.', 'Success');
        this.updateRestaurantPage();
      },
      err => {
        this._loading.isLoading(false);
        console.warn(err);
        this._toastr.error(err?.error?.message ? err.error.message : 'Couldn\'t decline.', 'Error');
      });
  }

  disable(id: number) {
    this._loading.isLoading(true);
    const model: IId = { Id: id };
    this._adminService.DisableRestaurant(model).subscribe(
      res => {
        this._loading.isLoading(false);
        this._toastr.info('Disabled.', 'Success');
        this.updateRestaurantPage();
      },
      err => {
        this._loading.isLoading(false);
        console.warn(err);
        this._toastr.error(err?.error?.message ? err.error.message : 'Couldn\'t decline.', 'Error');
      });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.data.filter = filterValue.trim().toLowerCase();

    if (this.data.paginator) {
      this.data.paginator.firstPage();
    }
  }

  OpenRestaurantDetails(id: number) {
    const dialogRef = this._dialog.open(RestaurantDetailsComponent, {
      data: {
        RestaurantId: id
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      this.updateRestaurantPage();
    });
  }
}
