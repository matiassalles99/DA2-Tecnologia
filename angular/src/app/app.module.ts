import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginRegisterPageComponent } from './_pages/login-register-page/login-register-page.component';
import { AuthenticationGuard } from './_guards/Authentication/authentication.guard';
import { AuthorizationGuard } from './_guards/Authentication/authorization.guard';
import { HttpClientModule } from '@angular/common/http';
import { ExampleComponent } from './_pages/example-component/example-component.component';
import { FatherComponent } from './_pages/father-component/father-component.component';
import { SonComponent } from './_pages/son-component/son-component.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginRegisterPageComponent,
    ExampleComponent,
    FatherComponent,
    SonComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [AuthenticationGuard, AuthorizationGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
