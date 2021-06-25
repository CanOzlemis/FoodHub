import { Component, ElementRef, Inject, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { JwtHelperService } from '@auth0/angular-jwt';
import { ToastrService } from 'ngx-toastr';
import { ApplicationUserService } from 'src/app/shared/application-user.service';
import { LoadingService } from 'src/app/shared/loading.service';

@Component({
  selector: 'app-chat-dialog',
  templateUrl: './chat-dialog.component.html',
  styleUrls: ['./chat-dialog.component.css']
})
export class ChatDialogComponent implements OnInit, OnDestroy {

  messageField: FormGroup;
  conversationHistory = [];
  RestaurantId;
  userId;
  conversationId;
  refresher;
  scrolltop: number = null;
  @ViewChild('commentEl') comment: ElementRef;

  constructor(
    private _formBuilder: FormBuilder,
    private _loading: LoadingService,
    private _userService: ApplicationUserService,
    private _toastr: ToastrService,
    @Inject(MAT_DIALOG_DATA) private data: { RestaurantId: number }
  ) {
    this._loading.isLoading(true);
    this.RestaurantId = data.RestaurantId;

    const helper = new JwtHelperService();
    const token = localStorage.getItem('token');
    this.userId = helper.decodeToken(token).UserID;

    this.messageField = this._formBuilder.group({
      message: ['', [Validators.required, Validators.maxLength(300)]]
    });

    //Initiate api with empty message in order to receive the conversationId. This can be accomplished by sending empty message string
    this._userService.SendChatMessageToRestaurant(this.RestaurantId, this.messageField.get('message').value).subscribe(
      (res: any) => {
        this._loading.isLoading(false);
        this.conversationId = res.ConversationId; //Setting the conversationId if it was not set while dialog was being openned up
        this.getConversation();
      },
      err => {
        this._loading.isLoading(true);
        this._toastr.error('Couldn\'t load message history!', 'Error', {timeOut: 5000});
        console.log(err);
      });

      this.refresher = setInterval(() => {
        this.getConversation();
      }, 6000); // repeat every 6 seconds

  }

  ngOnInit(): void {
  }


  ngOnDestroy(): void {
    /*
      * This has to be done to stop the loop from continuing none stop. Angular is a single page desing meaning that this page is 
      * never really closed hence we need to stop the interval once we are done with this component.
      */
    clearInterval(this.refresher);
  }

  sendMessage() {
    if (this.messageField.valid && this.messageField.get('message').value.trim() != "") {
      this._userService.SendChatMessageToRestaurant(this.RestaurantId, this.messageField.get('message').value).subscribe(
        (res: any) => {
          this.conversationId = res.ConversationId; //Setting the conversationId if it was not set while dialog was being openned up
          this._toastr.info('', 'Message sent');
          this.messageField.get('message').setValue("");
          this.getConversation();
        },
        err => {
          this._toastr.error('Couldn\'t send the message!', 'Error');
          console.log(err);
        });

    }else {
      this._toastr.warning('Message is not valid.', 'Did not send');
    }
  }


  getConversation() {

    if (this.conversationId == "") {
      return;
    }

    this._userService.GetConversation(this.conversationId).subscribe(
      res => {
        this.conversationHistory = res as [];

        //The timeout is for virtually waiting for the loop to be completed so that the height is correct.
        setTimeout(() => { this.scrolltop = this.comment.nativeElement.scrollHeight;}, 100);
      },
      err => {
        this._toastr.info('Previous conversations does not exist');
      });
  }
}
