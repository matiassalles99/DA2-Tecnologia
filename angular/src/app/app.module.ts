import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginRegisterPageComponent } from './_pages/login-register-page/login-register-page.component';
import { IndexAdminPageComponent } from './_pages/index-admin-page/index-admin-page.component';
import { AdminModule } from './_pages/admin/admin.module';
import { IndexAngularDocComponent } from './_pages/index-angular-doc/index-angular-doc.component';
import { AngularDocModule } from './_pages/angular-doc/angular-doc.module';
import { AuthenticationGuard } from './_guards/Authentication/authentication.guard';

@NgModule({
  declarations: [
    AppComponent,
    LoginRegisterPageComponent,
    IndexAdminPageComponent,
    IndexAngularDocComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AdminModule,
    AngularDocModule
  ],
  providers: [AuthenticationGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
