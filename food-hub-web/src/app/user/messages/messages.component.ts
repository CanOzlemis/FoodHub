import { Component, ElementRef, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { ToastrService } from 'ngx-toastr';
import { ApplicationUserService } from 'src/app/shared/application-user.service';
import { LoadingService } from 'src/app/shared/loading.service';

@Component({
  selector: 'app-messages',
  templateUrl: './messages.component.html',
  styleUrls: ['./messages.component.css']
})
export class MessagesComponent implements OnInit, OnDestroy {

  Conversations = [];
  toUserId;
  messageField: FormGroup;
  conversationHistory = [];
  conversationId: string = "";
  userId;
  toUserName;
  refresher;
  @ViewChild('commentEl') comment : ElementRef ;  
  scrolltop:number=null;

  constructor(
    private _formBuilder: FormBuilder,
    private _loading: LoadingService,
    private _userService: ApplicationUserService,
    private _toastr: ToastrService,
    private _router: Router,
    private _route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.getConversations();
    this.messageField = this._formBuilder.group({
      message: ['', [Validators.required, Validators.maxLength(300)]]
    });

    
    const helper = new JwtHelperService();
    const token = localStorage.getItem('token');
    this.userId = helper.decodeToken(token).UserID;

    this.refresher = setInterval(() => {
      this.getConversation();
      this.getConversations();
    }, 6000); // repeat every 6 seconds
    
  }


  ngOnDestroy(): void {
    /*
      * This has to be done to stop the loop from continuing none stop. Angular is a single page desing meaning that this page is 
      * never really closed hence we need to stop the interval once we are done with this component.
      */
    clearInterval(this.refresher);
  }

  getConversations(){
    this._userService.GetConversations().subscribe(
      res => {
        this.Conversations = res as [];
        this.fillParametersFromURL();
      },
      err => {
        this._toastr.error('Something went wrong while getting the conversations', 'Error');
      });
  }


  fillParametersFromURL(){
    if(this.conversationId !== "" && this.toUserId !== undefined){
      return;
    }
    
    this._route.queryParamMap.subscribe((params : any) => {
      this.toUserId = params?.params?.toUserId as string;
      this.toUserName = params?.params?.toUserName as string;

      if(this.toUserId != null){
        //Search the previous chats to see if it exists to be able to load previous chat history
        this.Conversations.forEach(element => {

          if(element.ConversationWithId == this.toUserId){
            this.conversationId = element.ConversationId;
          }

        });
        this.conversationId = this.conversationId === "" ? "" : this.conversationId;

        this.getConversation();
      }
    });
  }


  openConversation(toUserId: string, toUserName : string, conversationId: string){
    this.toUserId = toUserId;
    this.toUserName = toUserName;
    this.conversationId = conversationId;

    this.getConversation();
  }




  sendMessage(){
    if(this.messageField.valid && this.messageField.get('message').value.trim() != ""){
      this._userService.SendChatMessage(this.toUserId, this.messageField.get('message').value).subscribe(
        (res: any) => {
          this.conversationId = res.ConversationId; //Setting the conversationId if it was not set. AKA new chat.
          this._toastr.info('', 'Message sent');
          this.messageField.get('message').setValue("");
          this.getConversation();
        },
        err => {
          this._toastr.error('Couldn\'t send the message!', 'Error');
          console.log(err);
        }
      );
    } else {
      this._toastr.warning('Message is not valid.', 'Did not send');
    }
  }


  getConversation(){
    
    if(this.conversationId == ""){
      return;
    }

    this._userService.GetConversation(this.conversationId).subscribe(
      res => {
        this.conversationHistory = res as [];
        
        //The timeout is for virtually waiting for the loop to be completed so that the height is correct.
        setTimeout(() => {  this.scrolltop = this.comment.nativeElement.scrollHeight; }, 100);
        
      },
      err => {
        this._toastr.error('Failed to load messages!', 'Error');
      });
  }


arrayEmpty(array) {
  return !Array.isArray(array) || !array.length
}

}
