import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule, routingComponents } from './app-routing.module';
import { AppComponent } from './app.component';
import { MainMenuComponent } from './user/main-menu/main-menu.component';
import { OwnerMainMenuComponent } from "./owner/main-menu/main-menu.component";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSliderModule } from '@angular/material/slider';
import { NavbarComponent } from './navbar/navbar.component';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { StoreCardComponent } from './user/store-card/store-card.component';
import { MatCardModule } from '@angular/material/card';
import { FlexLayoutModule } from '@angular/flex-layout';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatDividerModule } from '@angular/material/divider';
import { MatInputModule } from '@angular/material/input';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { MatTableModule } from '@angular/material/table';
import { LoginComponent } from './login/login.component';
import { MatSelectModule } from '@angular/material/select';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { LoadingPageComponent } from './loading-page/loading-page.component';
import { ProfileComponent } from './user/profile/profile.component';
import { AuthInterceptor } from './auth/auth.interceptor';
import { ToastrModule } from 'ngx-toastr';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatMenuModule } from '@angular/material/menu';
import { ForbiddenComponent } from './forbidden/forbidden.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { MatTabsModule } from '@angular/material/tabs';
import { TemplateCardComponent } from './owner/template-card/template-card.component';
import { MatDialogConfig, MatDialogModule, MAT_DIALOG_DEFAULT_OPTIONS } from '@angular/material/dialog';
import { OwnerEditDialogComponent } from './Dialogs/owner-edit-dialog/owner-edit-dialog.component';
import { MatTooltipModule } from '@angular/material/tooltip';
import { NgxMaterialTimepickerModule } from 'ngx-material-timepicker';
import { OwnerMenuComponent } from './owner/owner-menu/owner-menu.component';
import { MatSortModule } from '@angular/material/sort';
import { ConfirmDialogComponent } from './Dialogs/confirm-dialog/confirm-dialog.component';
import { EditMenuItemDialogComponent } from './Dialogs/edit-menu-item-dialog/edit-menu-item-dialog.component';
import { CartComponent } from './user/cart/cart.component';
import { MatBadgeModule } from '@angular/material/badge';
import { SendOrderDialogComponent } from './Dialogs/send-order-dialog/send-order-dialog.component';
import { OrdersComponent } from './owner/orders/orders.component';
import { OrderDetailsDialogComponent } from './Dialogs/order-details-dialog/order-details-dialog.component';
import { MatListModule } from '@angular/material/list';
import { NgApexchartsModule } from 'ng-apexcharts';
import { AddReviewDialogComponent } from './Dialogs/add-review-dialog/add-review-dialog.component';
import { MatRadioModule } from '@angular/material/radio';
import { RatingAndReviewsComponent } from './owner/rating-and-reviews/rating-and-reviews.component';
import { AddResponseComponent } from './Dialogs/add-response/add-response.component';
import { EconomicsComponent } from './owner/economics/economics.component';
import { ConfirmMailComponent } from './confirm-mail/confirm-mail.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';
import { PartnerRegistrationComponent } from './partner-registration/partner-registration.component';
import { PartnerConfirmMailComponent } from './partner-confirm-mail/partner-confirm-mail.component';
import { AdminHomeComponent } from './administrator/admin-home/admin-home.component';
import { AdminRestaurantsComponent } from './administrator/admin-restaurants/admin-restaurants.component';
import { AdminUsersComponent } from './administrator/admin-users/admin-users.component';
import { MatPaginatorModule } from '@angular/material/paginator';
import { RejectOrderDialogComponent } from './Dialogs/reject-order-dialog/reject-order-dialog.component';
import { UserDetailsDialogComponent } from './Dialogs/user-details-dialog/user-details-dialog.component';
import { CartAndHistoryComponent } from './user/cart-and-history/cart-and-history.component';
import { SafePipe } from './shared/safe.pipe';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { EditProfileDialogComponent } from './Dialogs/edit-profile-dialog/edit-profile-dialog.component';
import { FeedbackDialogComponent } from './Dialogs/feedback-dialog/feedback-dialog.component';
import { FeedbackDetailsDialogComponent } from './Dialogs/feedback-details-dialog/feedback-details-dialog.component';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { NgxMaskModule, IConfig } from 'ngx-mask';
import { ChatDialogComponent } from './Dialogs/chat-dialog/chat-dialog.component';
import { MessagesComponent } from './user/messages/messages.component'
import { MatStepperModule } from '@angular/material/stepper';
import { RestaurantDetailsComponent } from './Dialogs/restaurant-details/restaurant-details.component';
import { ChangePasswordDialogComponent } from './Dialogs/change-password-dialog/change-password-dialog.component';


@NgModule({
  declarations: [
    AppComponent,
    MainMenuComponent,
    NavbarComponent,
    StoreCardComponent,
    routingComponents,
    LoginComponent,
    LoadingPageComponent,
    ProfileComponent,
    OwnerMainMenuComponent,
    ForbiddenComponent,
    NotFoundComponent,
    TemplateCardComponent,
    OwnerEditDialogComponent,
    OwnerMenuComponent,
    ConfirmDialogComponent,
    EditMenuItemDialogComponent,
    CartComponent,
    SendOrderDialogComponent,
    OrdersComponent,
    OrderDetailsDialogComponent,
    AddReviewDialogComponent,
    RatingAndReviewsComponent,
    AddResponseComponent,
    EconomicsComponent,
    ConfirmMailComponent,
    ResetPasswordComponent,
    PartnerRegistrationComponent,
    PartnerConfirmMailComponent,
    AdminHomeComponent,
    AdminRestaurantsComponent,
    AdminUsersComponent,
    RejectOrderDialogComponent,
    UserDetailsDialogComponent,
    CartAndHistoryComponent,
    SafePipe,
    EditProfileDialogComponent,
    FeedbackDialogComponent,
    FeedbackDetailsDialogComponent,
    ChatDialogComponent,
    MessagesComponent,
    RestaurantDetailsComponent,
    ChangePasswordDialogComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatSliderModule,
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatCardModule,
    FlexLayoutModule,
    FormsModule,
    MatExpansionModule,
    MatDividerModule,
    ReactiveFormsModule,
    MatInputModule,
    MatSnackBarModule,
    HttpClientModule,
    MatTableModule,
    MatSelectModule,
    MatSlideToggleModule,
    MatProgressBarModule,
    MatProgressSpinnerModule,
    MatSidenavModule,
    MatMenuModule,
    MatTabsModule,
    MatDialogModule,
    MatTooltipModule,
    MatSortModule,
    MatBadgeModule,
    MatListModule,
    MatRadioModule,
    MatPaginatorModule,
    MatCheckboxModule,
    MatStepperModule,
    ToastrModule.forRoot({
      timeOut: 2000,
      extendedTimeOut: 7000,
      progressBar: true,
      preventDuplicates: true,
      countDuplicates: true,
      maxOpened: 4,
      autoDismiss: true,
      positionClass: 'toast-bottom-right',
      enableHtml: true
    }),
    NgxMaterialTimepickerModule,
    NgApexchartsModule,
    FontAwesomeModule,
    NgxMaskModule.forRoot()
  ],
  providers: [
    LoadingPageComponent, 
    {
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true
  },
  {provide: MAT_DIALOG_DEFAULT_OPTIONS, 
    useValue: {
      ...new MatDialogConfig(),
      panelClass: "dialog-responsive",
      maxWidth: "100%",
    } as MatDialogConfig
  }
],
  bootstrap: [AppComponent]
})
export class AppModule { }
