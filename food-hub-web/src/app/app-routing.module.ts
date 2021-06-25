import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MenuComponent } from './user/menu/menu.component';
import { MainMenuComponent } from './user/main-menu/main-menu.component';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from './auth/auth.guard';
import { ProfileComponent } from './user/profile/profile.component';
import { OwnerMainMenuComponent } from './owner/main-menu/main-menu.component';
import { ForbiddenComponent } from './forbidden/forbidden.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { CartComponent } from './user/cart/cart.component';
import { ConfirmMailComponent } from './confirm-mail/confirm-mail.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';
import { PartnerRegistrationComponent } from './partner-registration/partner-registration.component';
import { PartnerConfirmMailComponent } from './partner-confirm-mail/partner-confirm-mail.component';
import { AdminHomeComponent } from './administrator/admin-home/admin-home.component';
import { CartAndHistoryComponent } from './user/cart-and-history/cart-and-history.component';
import { MessagesComponent } from './user/messages/messages.component';

const routes: Routes = [
  {
    path: '', //http://localhost:4200/
    component: MainMenuComponent, 
  },
  {
    path: 'menu/:name', //http://localhost:4200/menu/(name!id)
    component: MenuComponent,
  }, 
  {
    path: 'admin', //http://localhost:4200/admin
    component: AdminHomeComponent,
    canActivate: [AuthGuard],
    data: {permittedRoles:['Admin']}
  },
  {
    path: 'owner', //http://localhost:4200/owner
    component: OwnerMainMenuComponent,
    canActivate: [AuthGuard],
    data: {permittedRoles:['Owner']}
  },
  {
    path: 'profile', //http://localhost:4200/profile
    component: ProfileComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'messages', //http://localhost:4200/messages
    component: MessagesComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'cart-and-history', //http://localhost:4200/cart
    component: CartAndHistoryComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'login', //http://localhost:4200/login
    component: LoginComponent
  },
  {
    path: 'confirmMail', //http://localhost:4200/confirmMail
    component: ConfirmMailComponent
  },
  {
    path: 'partner/Registration', //http://localhost:4200/partner/Registration
    component: PartnerRegistrationComponent
  },
  {
    path: 'partner/confirmEmail', //http://localhost:4200/partner/confirmEmail
    component: PartnerConfirmMailComponent
  },
  {
    path: 'resetPassword', //http://localhost:4200/resetPassword
    component: ResetPasswordComponent
  },
  {
    path: 'forbidden', //http://localhost:4200/forbidden
    component: ForbiddenComponent
  },
  {
    path: '**', //404 not found wildcard
    component: NotFoundComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
export const routingComponents = [MenuComponent, MainMenuComponent];
