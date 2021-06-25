import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { faHeart } from '@fortawesome/free-regular-svg-icons';
import { faSearch, faSpinner } from '@fortawesome/free-solid-svg-icons';
import { ToastrService } from 'ngx-toastr';
import { ChatDialogComponent } from 'src/app/Dialogs/chat-dialog/chat-dialog.component';
import { IGetRestaurantDetail, IRestaurantDetail } from 'src/app/shared/interfaces';
import { LoadingService } from 'src/app/shared/loading.service';
import { RestaurantDetailService } from '../../shared/restaurant-detail.service';

@Component({
  selector: 'app-store-card',
  templateUrl: './store-card.component.html',
  styleUrls: ['./store-card.component.css']
})
export class StoreCardComponent implements OnInit {

  restaurants: IGetRestaurantDetail[];
  searchForm: FormGroup;


  sliderLabel(val) {
    return val;
  }

  constructor(
    private _RestaurantsDetailService: RestaurantDetailService,
    private _toastr: ToastrService,
    private _loading: LoadingService,
    private _formBuilder: FormBuilder,
    private _dialog: MatDialog) { }

  ngOnInit(): void {
    this._loading.isLoading(true);

    this.buildForm();
    this.getRestaurantList();


  }

  getRestaurantList() {
    this._loading.isLoading(true);
    let parameter = "";
    if(this.searchForm.get('Name').value || this.searchForm.get('City').value){
      parameter = "?"; //parameter indicator
      parameter += this.searchForm.get('Name').value == "" ? "" : "Name=" + this.searchForm.get('Name').value;
      parameter += parameter[parameter.length - 1] == "?" ? "" : "&" ; // parameter seperator
      parameter += this.searchForm.get('City').value == "" ? "" : "City=" + this.searchForm.get('City').value;
    }
    
    this._RestaurantsDetailService.Get(parameter).subscribe(
      res => {
        this._loading.isLoading(false);
        this.restaurants = res as IGetRestaurantDetail[];
      },
      err => {
        this._loading.isLoading(false);
        this._toastr.error('Couldn\'t receive restaurant data', 'Error', {
          timeOut: 10000
        });
      });
  }

  buildForm() {
    this.searchForm = this._formBuilder.group({
      Name: ['', []],
      City: ['', []]
    });
  }

  storeRating(currentStarIterator, storeRating) {
    if (currentStarIterator <= storeRating) {
      return true;
    } else if ((currentStarIterator - 1 < storeRating) && storeRating % 1) {
      return false;
    }

  }

  halfOrEmptyStar(currentStarIterator, storeRating) {
    if ((currentStarIterator - 1 < storeRating) && storeRating % 1) {
      return true;
    } else {
      return false;
    }
  }

  generateLinkParameter(name, id) {
    return (name + '!' + id);
  }

  arrayEmpty(array: any[]){
    return !Array.isArray(array) || !array.length;
  }

}
