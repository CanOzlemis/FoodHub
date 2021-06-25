import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IId, IRestaurantDetail, ISendMail } from './interfaces';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
  readonly link = 'api/Admin/';

  constructor(private http: HttpClient) { }


  GetRestaurants() {
    return this.http.get(this.link + 'Restaurants/GetAll');
  }

  
  GetApplicants(){
    return this.http.get(this.link + 'GetApplicants');
  }

  ApproveApplicant(model: IId){
    return this.http.post(this.link + 'Applicant/Approve', model);
  }

  DeclineApplicant(model: IId){
    return this.http.post(this.link + 'Applicant/Decline', model);
  }

  EnableRestaurant(model: IId){
    return this.http.post(this.link + 'EnableRestaurant', model);
  }

  DisableRestaurant(model: IId){
    return this.http.post(this.link + 'DisableRestaurant', model);
  }

  GetUsers(){
    return this.http.get(this.link + 'GetUsers');
  }

  DetailedUser(id: string){
    return this.http.get(this.link + 'GetUserDetails/' + id);
  }

  ResetUserPassword(id: string){
    const model = { UserId: id};
    return this.http.post(this.link + 'ResetUserPassword', model);
  }

  SendMail(model: ISendMail){
    return this.http.post(this.link + 'SendMail', model);
  }

  ConfirmPhoneNumber(id: string){
    const model = { UserId: id};
    return this.http.post(this.link + 'ConfirmPhoneNumber', model);
  }

  ConfirmEmail(id: string){
    const model = { UserId: id};
    return this.http.post(this.link + 'ConfirmEmail', model);
  }

  GetFeedbacks(){
    return this.http.get(this.link + 'GetFeedbacks');
  }

  GetRestaurantDetails(id: number){
    return this.http.get(this.link + 'RestaurantDetails/' + id);
  }

  BanUser(id: string){
    return this.http.post(this.link + 'BanUser', {'UserId': id});
  }

  UnbanUser(id: string){
    return this.http.post(this.link + 'UnbanUser', {'UserId': id});
  }

  GetUserReviews(id: string){
    return this.http.get(this.link + 'GetUserReviews/' + id);
  }

  DeleteReview(id: number){
    return this.http.delete(this.link + 'DeleteReview/' + id);
  }

  
}
