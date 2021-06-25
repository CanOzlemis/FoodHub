import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { IRestaurantDetail, IWorkingTime } from 'src/app/shared/interfaces';
import { LoadingService } from 'src/app/shared/loading.service';
import { OwnerService } from 'src/app/shared/owner.service';




enum days {
  Monday,
  Thuesday,
  Wednesday,
  Thursday,
  Friday,
  Saturday,
  Sunday
}

interface IEditedRestaurantDetails {
  About: string,
  AverageDeliveryTime: number,
  MinOrderPrice: number,
  MapSrc: string,
  Facebook: string,
  Instagram: string,
  Twitter: string,
  PhoneNumber: string,
  Image: any
}

interface IEditedWorkingTimes {
  Day: number,
  OpenTime: string,
  CloseTime: string
}



@Component({
  selector: 'app-owner-edit-dialog',
  templateUrl: './owner-edit-dialog.component.html',
  styleUrls: ['./owner-edit-dialog.component.css']
})
export class OwnerEditDialogComponent implements OnInit {

  editorForm: FormGroup;
  isHelpOpen = false;
  restaurantDetails: IRestaurantDetail;
  workingTimes: IWorkingTime[];
  InputOpenTimes: string[] = [];
  InputCloseTimes: string[] = [];
  srcResult;
  displayImage;
  base64Data;

  constructor
    (
      private _formBuilder: FormBuilder,
      private _loading: LoadingService,
      private _ownerService: OwnerService,
      private _toastr: ToastrService,
      private dialogRef: MatDialogRef<OwnerEditDialogComponent>
    ) {
    this._loading.isLoading(true);
    this.initForm(); // have to initialise form in constructor because dialog is loading too quick before form is built

  }

  ngOnInit(): void {


    this._ownerService.GetRestaurantDetails().subscribe(
      (res: any) => {
        this._loading.isLoading(false);
        this.restaurantDetails = res.restaurantDetail as IRestaurantDetail;
        this.workingTimes = res.workingTime as IWorkingTime[];
        this.populateForm(this.restaurantDetails);
        this.displayImage = res.Image ? 'data:image/jpeg;base64,' + res.Image : null;

        this.workingTimes.forEach(element => {
          this.InputOpenTimes.push(element.OpenAt.Hour + ":" + element.OpenAt.Minute);
          this.InputCloseTimes.push(element.CloseAt.Hour + ":" + element.CloseAt.Minute);
        });


      },
      err => {
        this._loading.isLoading(false);
        this._toastr.error("Could not load restaurant details.", "Error", {
          timeOut: 10000
        });
        console.warn(err);
      });
  }


  initForm() {
    this.editorForm = this._formBuilder.group({
      name: [{ value: '', disabled: true }, []],
      about: ['', [
        Validators.max(200)
      ]],
      averageDeliveryTime: ['', [
        Validators.required,
        Validators.min(0),
        Validators.max(99)
      ]],
      facebook: [''],
      instagram: [''],
      twitter: [''],
      phoneNumber: ['', [
        Validators.pattern("^[0-9]*$"),
        Validators.minLength(11)
      ]],
      minOrderPrice: ['', [
        Validators.required,
        Validators.min(0),
        Validators.max(999)
      ]],
      embeddedMap: [''],
      mapSrc: [{ value: '', disabled: true }, []]
    });
  }

  populateForm(data: IRestaurantDetail) {
    this.editorForm.patchValue({
      name: data.Name,
      about: data.About,
      averageDeliveryTime: data.AverageDeliveryTime,
      minOrderPrice: data.MinOrderPrice,
      mapSrc: data.MapSrc,
      facebook: data.Facebook,
      instagram: data.Instagram,
      twitter: data.Twitter,
      phoneNumber: data.PhoneNumber
    });
  }

  enumToDay(val: number) {
    return days[val];
  }

  saveChanges() {

    if (!this.editorForm.valid) {
      this._toastr.error('Profile details are not valid', 'Error');
      return;
    }


    const newRestaurantDetails: IEditedRestaurantDetails = {
      About: this.editorForm.get('about').value,
      AverageDeliveryTime: this.editorForm.get('averageDeliveryTime').value,
      MinOrderPrice: this.editorForm.get('minOrderPrice').value,
      MapSrc: this.editorForm.get('mapSrc').value,
      Facebook: this.parseSocialMediaLink(this.editorForm.get('facebook').value),
      Instagram: this.parseSocialMediaLink(this.editorForm.get('instagram').value),
      Twitter: this.parseSocialMediaLink(this.editorForm.get('twitter').value),
      PhoneNumber: this.editorForm.get('phoneNumber').value,
      Image: this.base64Data
    };

    let newResstaurantWorkingTimes: IEditedWorkingTimes[] = [];

    for (let index = 0; index < this.InputOpenTimes.length; index++) {

      if (this.InputOpenTimes[index] > this.InputCloseTimes[index]) { //Invalid times
        this._toastr.error(
          '(' + days[index] + ', ' + this.InputOpenTimes[index] + ' - ' + this.InputCloseTimes[index] + '). Restaurant cant open before closing time!', 'Time error',
          {
            timeOut: 10000
          });
        return;
      }

      newResstaurantWorkingTimes.push({
        Day: index,
        OpenTime: this.InputOpenTimes[index],
        CloseTime: this.InputCloseTimes[index]
      });

    }
    //If everything is correct, close the dialog and return the values
    this.dialogRef.close([newRestaurantDetails, newResstaurantWorkingTimes]);
  }


  tryParseLink() {

    let originalInput: string = this.editorForm.get('embeddedMap').value;
    let parsedInput;

    if (originalInput) {
      let startIndex = originalInput.search('src=');
      let endIndex = originalInput.indexOf('"', startIndex + 5);
      if (startIndex != -1 && endIndex != -1) {
        parsedInput = originalInput.substring(startIndex + 5, endIndex);
        this.editorForm.get('mapSrc').setValue(parsedInput);
        this._toastr.success('Link is confirmed', 'Success');
      } else {
        this._toastr.error('The link is not correct', 'Error');
      }
    } else {
      this._toastr.error('Input field for "Google map source" is empty', 'Error');
    }
  }




  onFileSelected(fileEvent: any, fileInput: any) {

    this._toastr.info('Image process started...', 'Process started');
    if (!fileEvent) { // If there is no file selected don't run the function
      this._toastr.error('Image process stopped...', 'No file selected');
      return;
    }

    const file = fileEvent.target.files[0];
    const maxSizekB = 10 * 1024;

    if (file.type && (file.type == "image/jpeg" || file.type == "image/png")) {

      if (file.size / (1024) > maxSizekB) { //check file size
        this._toastr.warning('File size is too large! The size of your image: ' + (file.size / (1024 * 1024) as number).toFixed(2) + ' MB. Max allowed is ' + maxSizekB + ' KB', 'File too large!', { timeOut: 10000 });
        fileInput.value = ""; // Unselect the file
        return;
      }

      const inputNode: any = document.querySelector('#file');

      if (typeof (FileReader) !== 'undefined') {
        const reader = new FileReader();
        reader.readAsArrayBuffer(inputNode.files[0]);

        reader.onload = (e: any) => {
          this.srcResult = e.target.result;
          this._arrayBufferToBase64(this.srcResult);
        }

      }

    } else {
      this._toastr.error('The file extension is not accepted. Please upload a image that is either a ".jpeg" or ".png"', 'Unknown image format!', { timeOut: 10000 });
      fileInput.value = ""; // Unselect the file
      return;
    }


  }


  _arrayBufferToBase64(buffer) {
    var binary = '';
    var bytes = new Uint8Array(buffer);
    var len = bytes.byteLength;
    for (var i = 0; i < len; i++) {
      binary += String.fromCharCode(bytes[i]);
    }
    this.base64Data = window.btoa(binary);
    this.displayImage = "data:image/jpg;base64, " + this.base64Data; // the image to be displayed stored locally to safe on performance.
    
    this._toastr.info('Image process is complete', 'Process complete');

  }


  parseSocialMediaLink(link: string){
    if(link?.length > 0){
      let userNameIndex = link.lastIndexOf('.com/');
      if(userNameIndex != -1){
        return link.substr(userNameIndex + 5);
      }
    }
    return link;
  }



}
