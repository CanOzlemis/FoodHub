import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { Observable } from "rxjs";
import { tap } from "rxjs/operators";

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

    constructor(private router : Router) {
        
    }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> { //Intercepting the calls to add the token to the header
        if(localStorage.getItem('token') !== null){
            const cloneReq = req.clone({
                headers: req.headers.set('Authorization', 'Bearer ' + localStorage.getItem('token'))
            });
            return next.handle(cloneReq).pipe(
                tap(
                    succ => {},
                    err => {
                        if (err.status == 401){ //Unknown token from server ( AKA not authorized )
                            localStorage.removeItem('token');
                            this.router.navigateByUrl('/login');
                        }else if (err.status == 403){ //The role does not have access to this page
                            this.router.navigateByUrl('/forbidden');
                        }
                    }
                )
            )
        } else {
            return next.handle(req.clone());
        }
    }

}