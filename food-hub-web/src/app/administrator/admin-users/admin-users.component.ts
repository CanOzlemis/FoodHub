import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ToastrService } from 'ngx-toastr';
import { UserDetailsDialogComponent } from 'src/app/Dialogs/user-details-dialog/user-details-dialog.component';
import { AdminService } from 'src/app/shared/admin.service';
import { LoadingService } from 'src/app/shared/loading.service';

@Component({
  selector: 'app-admin-users',
  templateUrl: './admin-users.component.html',
  styleUrls: ['./admin-users.component.css']
})
export class AdminUsersComponent implements OnInit {
  displayedColumns = ['Id', 'Name', 'Email', 'PhoneNumber', 'Created', 'Updated', 'Role', 'Details'];
  data;

  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(
    private _adminService: AdminService,
    private _toastr: ToastrService,
    private _loading: LoadingService,
    private _dialog: MatDialog) { }

  ngOnInit(): void {
    this.updateUsers();
    
  }


  updateUsers(){
    this._loading.isLoading(true);

    this._adminService.GetUsers().subscribe(
      (res: any) => {
        this._loading.isLoading(false);
        this.data = new MatTableDataSource(res);
        this.data.sort = this.sort;
        this.data.paginator = this.paginator;
      },
      err => {
        this._loading.isLoading(false);
        this._toastr.error('Couldn\'t load users', 'Error');
        console.warn(err);
      });
  }

  openUser(userId: string){
    let dialogRef = this._dialog.open(UserDetailsDialogComponent, {
      data: { UserId: userId }
    });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.data.filter = filterValue.trim().toLowerCase();

    if (this.data.paginator) {
      this.data.paginator.firstPage();
    }
  }


}
