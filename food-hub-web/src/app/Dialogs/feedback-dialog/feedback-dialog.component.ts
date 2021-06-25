import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ApplicationUserService } from 'src/app/shared/application-user.service';

@Component({
  selector: 'app-feedback-dialog',
  templateUrl: './feedback-dialog.component.html',
  styleUrls: ['./feedback-dialog.component.css']
})
export class FeedbackDialogComponent implements OnInit {

  feedbackForm: FormGroup;

  constructor(    
    private _formBuilder: FormBuilder,
    private _userService: ApplicationUserService,
    private _toastr: ToastrService) { 
      this.buildForm();
    }

  ngOnInit(): void {
  }

  
  buildForm(){
    this.feedbackForm = this._formBuilder.group({
      type: ['', Validators.required],
      message: ['', Validators.required]
    });
  }

  sendFeedback(){
    if(this.feedbackForm.valid){
      this._userService.SendFeedback(this.feedbackForm.get('type').value, this.feedbackForm.get('message').value).subscribe(
        res => {
          this._toastr.success('Your feedback has been submitted. Thank you!', 'Success');
        },
        err => {
          this._toastr.error(err?.error?.message ? err.error.message : 'Couldn\'t send your feedback.' , 'Failed');
          console.warn(err);
        }
      );

    }else {
      this._toastr.error('Can\'t send a feedback with empty fields!', 'Error');
    }
  }
}
