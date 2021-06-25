import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IRestaurantDetail } from './interfaces';

@Injectable({
  providedIn: 'root'
})
export class RestaurantDetailService {

  readonly URL= 'api/RestaurantDetail';

  constructor(private http: HttpClient) { }


  Get(parameter : string){
    return this.http.get(this.URL + parameter);
  }

  GetById(id:number){
    return this.http.get(this.URL + '/' + id);
  }

  GetMenu(id:number){
    return this.http.get(this.URL + '/Menu/' + id);
  }

  GetReviewAndComments(id:number){
    return this.http.get(this.URL + '/GetReviewAndComments/' + id);
  }



}
