import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthenticationGuard } from './_guards/Authentication/authentication.guard';
import { AuthorizationGuard } from './_guards/Authentication/authorization.guard';
import { IndexAdminPageComponent } from './_pages/index-admin-page/index-admin-page.component';
import { IndexAngularDocComponent } from './_pages/index-angular-doc/index-angular-doc.component';
import { LoginRegisterPageComponent } from './_pages/login-register-page/login-register-page.component';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: LoginRegisterPageComponent
  },
  {
    canActivate:[AuthenticationGuard, AuthorizationGuard],
    path: 'admin',
    component: IndexAdminPageComponent,
    loadChildren: () => import('./_pages/admin/admin.module').then(m => m.AdminModule)
  },
  {
    path: 'angular-doc',
    component: IndexAngularDocComponent,
    loadChildren: () => import('./_pages/angular-doc/angular-doc.module').then(m => m.AngularDocModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
