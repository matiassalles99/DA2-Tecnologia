import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FatherComponentComponent } from './father-component/father-component.component';

const routes: Routes = [
  {
    path: 'component-interaction',
    component: FatherComponentComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AngularDocRoutingModule { }
