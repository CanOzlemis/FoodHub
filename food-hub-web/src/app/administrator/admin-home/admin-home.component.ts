import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { MatTabChangeEvent } from '@angular/material/tabs';
import { ToastrService } from 'ngx-toastr';
import { FeedbackDetailsDialogComponent } from 'src/app/Dialogs/feedback-details-dialog/feedback-details-dialog.component';
import { UserDetailsDialogComponent } from 'src/app/Dialogs/user-details-dialog/user-details-dialog.component';
import { AdminService } from 'src/app/shared/admin.service';
import { IFeedback } from 'src/app/shared/interfaces';
import { AdminRestaurantsComponent } from '../admin-restaurants/admin-restaurants.component';
import { AdminUsersComponent } from '../admin-users/admin-users.component';

@Component({
  selector: 'app-admin-home',
  templateUrl: './admin-home.component.html',
  styleUrls: ['./admin-home.component.css']
})
export class AdminHomeComponent implements OnInit {

  displayedColumns =['Id', 'Type', 'Message', 'Created', 'Actions'];
  dataSource;
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild('tabRestaurants') restaurantsComponent: AdminRestaurantsComponent; // using this to trigger functions inside the component so that the chart can be rendered
  @ViewChild('tabUsers') usersComponent: AdminUsersComponent;

  constructor(
    private _adminService: AdminService,
    private _toastr: ToastrService,
    private _dialog: MatDialog) { }

  ngOnInit(): void {
    this._adminService.GetFeedbacks().subscribe(
      (res:any) => {
        this.dataSource = new MatTableDataSource(res);
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
      },
      err => {
        this._toastr.error('Could\'t load feedbacks');
      });
  }


  
  openUser(userId: string){
    let dialogRef = this._dialog.open(UserDetailsDialogComponent, {
      data: { UserId: userId }
    });
  }

  openFeedback(element: IFeedback){
    let dialogRef = this._dialog.open(FeedbackDetailsDialogComponent, {
      data: element
    });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
    
    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }



  
  onTabChanged(matTabEvent: MatTabChangeEvent) {

    //Update the tab when clicked to have the most recent information

    if (matTabEvent.tab.textLabel === "Restaurants") { 
      this.restaurantsComponent.ngOnInit();
    } else if (matTabEvent.tab.textLabel === "Users"){
      this.usersComponent.ngOnInit();
    }

  }


}
