import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-main-menu',
  templateUrl: './main-menu.component.html',
  styleUrls: ['./main-menu.component.css']
})
export class MainMenuComponent implements OnInit {

  constructor(private _router: Router) { }


  ngOnInit(): void {
    if (localStorage.getItem('token')) {
      var payload = JSON.parse(window.atob(localStorage.getItem('token').split('.')[1])); //grabbing the part of token where role is kept
      var userRole = payload.role;
      if (userRole === "Owner") {
        this._router.navigateByUrl("/owner");
      } else if (userRole === "Admin") {
        //this._router.navigateByUrl("/admin");
      }
    }

  }

}
