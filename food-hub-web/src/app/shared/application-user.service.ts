import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IApplicantRestaurant, IConfirmMail, IId, IPartnerConfirmMail, IPostOrder, IPostReviewAndComment, IResetPassword, IResetPasswordMail, IUserRegistration } from './interfaces';
import { JwtHelperService } from "@auth0/angular-jwt";
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class ApplicationUserService {

  readonly URL = 'api/Users';

  constructor(private http: HttpClient,
              private _router : Router,
              private _toastr : ToastrService) { }


  RegisterUser(data: IUserRegistration) {
    return this.http.post(this.URL + '/Register', data);
  }
  
  Login(user){
    //user : {Email : string , Password : string}

    return this.http.post( this.URL + "/Login", user);
  }

  userInfo () {
    return this.http.get( this.URL + "/UserInfo");
  }

  isLoggedIn(){

    const helper = new JwtHelperService();
    const token = localStorage.getItem('token');
    

    if(token !== null){  // If the user is logged in
      const tokenExpired = helper.isTokenExpired(token);

      //!!!! CURRENTLY WE ARE NOT REFRESHING THE TOKEN, JUST SENDING THEM TO LOGINs !!!!
      if (tokenExpired) { // the users token has expired, renew the token 
        this._toastr.error('Token has expired', 'Error');
        localStorage.removeItem('token');
        this._router.navigateByUrl("/login");
        return false;
        
      }
      return true;
    }
    return false;
  }


  roleMatch(authorizedRoles):boolean {
    var isMatch = false;
    var payload = JSON.parse(window.atob(localStorage.getItem('token').split('.')[1])); //grabbing the part of token where role is kept
    var userRole = payload.role;
    authorizedRoles.forEach(element => {
      if(userRole == element){
        isMatch = true;
        return false;
      }
    });
    return isMatch;
  }


  PostOrder(order: IPostOrder){
    return this.http.post(this.URL + '/SendOrder', order);
  }

  GetOrderHisory(page: number){
    return this.http.get(this.URL + '/GetOrderHistory/' + page);
  }

  PostReviewAndComment(model: IPostReviewAndComment){
    return this.http.post(this.URL + '/AddReviewAndComment', model);
  }

  ConfirmMail(model: IConfirmMail) {
    return this.http.post(this.URL + '/ConfirmMail', model);
  }

  ResetPasswordMail(model: IResetPasswordMail) {
    return this.http.post(this.URL + '/ResetPasswordMail', model);
  }

  ResetPassword(model: IResetPassword) {
    return this.http.post(this.URL + '/ResetPassword', model);
  }

  AddApplicantRestaurant(model: IApplicantRestaurant) {
    return this.http.post(this.URL + '/AddApplicantRestaurant', model);
  }
  
  PartnerConfirmMail(model: IPartnerConfirmMail) {
    return this.http.post(this.URL + '/PartnerConfirmMail', model);
  }

  ToggleFavorite(model: IId) {
    return this.http.post(this.URL + '/ToggleFavorite', model);
  }

  GetAddress(){
    return this.http.get(this.URL + "/GetAddress");
  }

  UpdateAddress(address : string){
    return this.http.post(this.URL + "/ChangeAddress", {"Text": address});
  }

  SendFeedback(topic : string, message : string){
    return this.http.post(this.URL + "/Feedback", {"FeedbackType": topic, "Message": message});
  }

  SendChatMessage(toUserId: string, message: string){
    return this.http.post(this.URL + "/SendChatMessage", {"ToUserId": toUserId, "Message": message});
  }

  SendChatMessageToRestaurant(restaurantId: number, message: string){
    return this.http.post(this.URL + "/SendChatMessageToRestaurant", {"RestaurantId": restaurantId, "Message": message});
  }

  GetConversation(id:string){
    return this.http.get(this.URL + "/GetConversation/" + id);
  }
  
  GetConversations(){
    return this.http.get(this.URL + "/GetConversations");
  }
  
  GetUnreadCount(){
    return this.http.get(this.URL + "/GetUnreadCount");
  }

  ResendConfirmationMail(email: string){
    return this.http.post(this.URL + "/ResendConfirmationMail", {"Text": email});
  }

  ChangePassword(password: string) {
    return this.http.post(this.URL + '/ChangePassword', {"Text": password});
  }
}
