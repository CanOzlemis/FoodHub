import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ApplicationUserService } from '../shared/application-user.service';
import { IConfirmMail } from '../shared/interfaces';
import { LoadingService } from '../shared/loading.service';

@Component({
  selector: 'app-confirm-mail',
  templateUrl: './confirm-mail.component.html',
  styleUrls: ['./confirm-mail.component.css']
})
export class ConfirmMailComponent implements OnInit {
  Id: string;
  Hash: string;

  constructor(
    private _route: ActivatedRoute, 
    private _toastr: ToastrService, 
    private _user: ApplicationUserService,
    private _router: Router,
    private _loading: LoadingService) { }

  ngOnInit(): void {
    this._loading.isLoading(true);
    this._route.queryParamMap.subscribe((params : any) => {
      this.Id = params?.params?.id as string;
      this.Hash = params?.params?.hash as string;

      if(this.Id == null && this.Hash == null){
        this._toastr.error('Invalid link!', 'Error');
        this._router.navigateByUrl("/login");
      }else {

        let tempHashChars:any = [];
        for(let i = 0; i < this.Hash.length; i++){ // Hash fix, when the hash contains '+' the url converts it to '%20' which when reading converts to empty space
          tempHashChars[i] = this.Hash[i] == ' ' ? '+': this.Hash[i];
        }
  
        this.Hash = tempHashChars.join('');

        const model :IConfirmMail = {UserId: this.Id, Hash: this.Hash};
        this._user.ConfirmMail(model).subscribe(
          res => {
            this._loading.isLoading(false);
            this._toastr.success('Mail confirmation successful', 'Success');
            this._router.navigateByUrl("/login");
          },
          err => {
            this._loading.isLoading(false);
            this._toastr.error( err?.error?.message ? err.error.message : 'Mail confirmation failed.', 'Could not confirm mail', {timeOut: 7000});
            this._router.navigateByUrl("/login");
          });

        
      }
    });
  }

}
