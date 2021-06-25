import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { faBullhorn, faCommentAlt, faFlagUsa, faHome, faShoppingCart, faSignInAlt, faSignOutAlt, faUserAlt, faUserCog } from '@fortawesome/free-solid-svg-icons';
import { ToastrService } from 'ngx-toastr';
import { FeedbackDialogComponent } from '../Dialogs/feedback-dialog/feedback-dialog.component';
import { ApplicationUserService } from '../shared/application-user.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit, OnDestroy {

  UnreadCount: number = -1;
  refresher;
  IconCart = faShoppingCart;
  IconHome = faHome;
  IconLogout = faSignOutAlt;
  IconLogin = faSignInAlt;
  IconUser = faUserAlt;
  IconAdmin = faUserCog;
  IconFeedback = faBullhorn;
  IconMessage = faCommentAlt

  constructor(private _router: Router,
    public _userService: ApplicationUserService,
    private _toastr: ToastrService,
    private _dialog: MatDialog) { }


  ngOnInit(): void {
    if (localStorage.getItem('token') && localStorage.getItem('token') != null) {
    } else {
      //this._router.navigateByUrl("/login");
    }
    this.UnreadMessagesCount();

    this.refresher = setInterval(() => {
      this.UnreadMessagesCount();
    }, 6000); // repeat every 6 seconds
  }

  ngOnDestroy(): void {
    /*
      * This has to be done to stop the loop from continuing none stop. Angular is a single page desing meaning that this page is 
      * never really closed hence we need to stop the interval once we are done with this component.
      */
    clearInterval(this.refresher);
  }

  onLogout() {
    localStorage.removeItem('token');
    localStorage.removeItem('cart');
    //reset the values for the next login:
    this.UnreadCount = -1;
    this._router.navigateByUrl("/login");
  }

  openFeedbackDialog() {
    const dialogRef = this._dialog.open(FeedbackDialogComponent);
  }

  UnreadMessagesCount() {
    if (!this._userService.isLoggedIn()) {
      return;
    }

    this._userService.GetUnreadCount().subscribe(
      res => {
        if (res && this.UnreadCount != -1 && this.UnreadCount != res) { //If both the unread count and res is not 0 and the number is not same, it must be same message
          this._toastr.info('You just received a new message', 'New message!')
        }
        this.UnreadCount = res as number;
      },
      err => {
        this._toastr.error('Could\'t get the unread messages count', 'Error');
      }
    );
  }
}
