import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IId } from './interfaces';


interface IEditedRestaurantDetails {
  About: string,
  AverageDeliveryTime: number,
  MinOrderPrice: number
}

interface IEditedWorkingTimes {
  Day: number,
  OpenTime: string,
  CloseTime: string
}


@Injectable({
  providedIn: 'root'
})
export class OwnerService {

  readonly link = 'api/Owner/';

  constructor(private http: HttpClient) { }


  GetRestaurantDetails() {
    return this.http.get(this.link + 'OwnerRestaurantDetails');
  }

  GetMenuList() {
    return this.http.get(this.link + 'Menu');
  }

  DeleteMenuItem(id) {
    return this.http.delete(this.link + 'Menu/' + id)
  }

  UpdateMenuItem(val){
    return this.http.patch(this.link + 'Menu/Update', val);
  }

  PostItemToMenu(val: object){
    return this.http.post(this.link + 'AddItemToMenu', val);
  }

  UpdateRestaurantDetails(val : object ) {
    return this.http.patch(this.link + 'Update', val);
  }

  GetOrders(){
    return this.http.get(this.link + 'GetOrders');
  }

  GetDailyOrderChartData() {
    return this.http.get(this.link + 'GetDailyOrderChartData');
  }

  AcceptOrder(OrderId: number){
    return this.http.patch(this.link + 'Order/AcceptOrder', {OrderId: OrderId});
  }

  CompleteOrder(OrderId: number){
    return this.http.patch(this.link + 'Order/CompleteOrder', {OrderId: OrderId});
  }

  RejectOrder(model){ //{} Note: string, OrderId: number}
    return this.http.patch(this.link + 'Order/RejectOrder', model);
  }

  GetReviewAndResponses(){
    return this.http.get(this.link + 'GetReviewAndResponses');
  }

  AddResponse(model){
    return this.http.patch(this.link + 'AddResponse', model);
  }

  DeleteComment(model: IId){
    return this.http.patch(this.link + 'DeleteComment', model);
  }

  ConfirmPhoneNumber(UserId: string){
    var string = '{ "UserId":"' + UserId + '"}';
    return this.http.patch(this.link + 'ConfirmPhoneNumber', JSON.parse(string));
  }

  GetEarningsHistory(){
    return this.http.get(this.link + 'GetEarningsHistory');
  }

  GetEarningsData() {
    return this.http.get(this.link + 'GetEarningsData');
  }

  DisableRestaurant() {
    return this.http.patch(this.link + 'DisableRestaurant', {});
  }

  RequestRestaurantActivation() {
    return this.http.patch(this.link + 'RequestRestaurantActivation', {});
  }


}
