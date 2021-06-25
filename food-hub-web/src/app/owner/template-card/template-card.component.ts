import { Component, Input, OnInit } from '@angular/core';
import { IRestaurantDetail, IWorkingTime } from 'src/app/shared/interfaces';

@Component({
  selector: 'app-template-card',
  templateUrl: './template-card.component.html',
  styleUrls: ['./template-card.component.css']
})
export class TemplateCardComponent implements OnInit {
  @Input() restaurant: IRestaurantDetail;
  @Input() workingTime: IWorkingTime[];
  @Input() Image: any;
  now: number;

  constructor() { }

  ngOnInit(): void {
    this.now = (new Date().getDay() + 6) % 7; // + 6 and % 7 because for system the day 0 is Sunday. Made it like this for making the first day Monday
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

}
