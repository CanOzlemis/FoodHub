import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ApplicationUserService } from '../shared/application-user.service';
import { IPartnerConfirmMail } from '../shared/interfaces';
import { LoadingService } from '../shared/loading.service';

@Component({
  selector: 'app-partner-confirm-mail',
  templateUrl: './partner-confirm-mail.component.html',
  styleUrls: ['./partner-confirm-mail.component.css']
})
export class PartnerConfirmMailComponent implements OnInit {

  GUID: string;
  Id: number;

  constructor(private _route: ActivatedRoute,
    private _toastr: ToastrService,
    private _user: ApplicationUserService,
    private _router: Router,
    private _loading: LoadingService) { }

  ngOnInit(): void {

    this._loading.isLoading(true);
    this._route.queryParamMap.subscribe((params: any) => {
      this.GUID = params?.params?.guid as string;
      this.Id = parseInt(params?.params?.id); //Need to parse the value to int otherwise it ends up being a string

      if (this.Id == null && this.GUID == null) {
        this._toastr.error('Invalid link!', 'Error');
        this._router.navigateByUrl("/login");
      } else {

        let tempGUIDChars: any = [];
        for (let i = 0; i < this.GUID.length; i++) { // GUID fix, when the hash contains '+' the url converts it to '%20' which when reading converts to empty space
          tempGUIDChars[i] = this.GUID[i] == ' ' ? '+' : this.GUID[i];
        }

        this.GUID = tempGUIDChars.join('');

        const model: IPartnerConfirmMail = { GUID: this.GUID, Id: this.Id };
        console.log(model);
        this._user.PartnerConfirmMail(model).subscribe(
          res => {
            this._loading.isLoading(false);
            this._toastr.success('Mail confirmation successful', 'Success');
            this._router.navigateByUrl("/login");
          },
          err => {
            this._loading.isLoading(false);
            console.log(err);
            this._toastr.error(err?.error?.message ? err.error.message : 'Mail confirmation failed.', 'Could not confirm mail', { timeOut: 7000 });
            this._router.navigateByUrl("/login");
          });


      }
    });
  }

}


