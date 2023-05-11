import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from '../pages/home/home.component';
import { LoginComponent } from '../pages/login/login.component';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: HomeComponent,
  },
  {
    path: 'login',
    pathMatch: 'full',
    component: LoginComponent,
  },
  // {
  //   canActivate:[AuthenticationGuard],
  //   path: 'admin',
  //   component: IndexAdminPageComponent,
  //   loadChildren: () => import('./_pages/admin/admin.module').then(m => m.AdminModule)
  // },
  // {
  //   path: 'angular-doc',
  //   component: IndexAngularDocComponent,
  //   loadChildren: () => import('./_pages/angular-doc/angular-doc.module').then(m => m.AngularDocModule)
  // }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
