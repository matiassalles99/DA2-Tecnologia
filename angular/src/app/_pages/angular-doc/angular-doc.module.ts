import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AngularDocRoutingModule } from './angular-doc-routing.module';
import { FatherComponentComponent } from './father-component/father-component.component';
import { SonComponentComponent } from './son-component/son-component.component';


@NgModule({
  declarations: [
    FatherComponentComponent,
    SonComponentComponent
  ],
  imports: [
    CommonModule,
    AngularDocRoutingModule
  ]
})
export class AngularDocModule { }
