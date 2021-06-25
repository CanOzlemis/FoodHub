import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { ApplicationUserService } from '../shared/application-user.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(
    private _router: Router,
    private _userSevice: ApplicationUserService) {


  }


  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): boolean {
    if (localStorage.getItem('token') != null) {

      const roles = next.data['permittedRoles'] as Array<string>;
      if (roles) {

        if (this._userSevice.roleMatch(roles)) {
          return true
        } else {
          this._router.navigate(['/forbidden']);
          return false;
        }

      }
      return true;
    }
    else {
      this._router.navigate(['/login']);
      return false;
    }

  }

}
