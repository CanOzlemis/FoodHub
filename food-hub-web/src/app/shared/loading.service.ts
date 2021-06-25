import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoadingService {

  private value = new BehaviorSubject<boolean>(false);
  currentValue = this.value.asObservable();

  constructor() { }

  isLoading(input:boolean){
      this.value.next(input);
  }
  
}
