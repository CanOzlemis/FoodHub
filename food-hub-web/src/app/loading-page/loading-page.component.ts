import { Component, OnInit } from '@angular/core';
import { LoadingService } from '../shared/loading.service';

@Component({
  selector: 'app-loading-page',
  templateUrl: './loading-page.component.html',
  styleUrls: ['./loading-page.component.css']
})
export class LoadingPageComponent implements OnInit {


  loading = false;
  constructor(private _loading : LoadingService) { }

  ngOnInit(): void {
    this._loading.currentValue.subscribe(val => this.loading = val);
  }

  
}
