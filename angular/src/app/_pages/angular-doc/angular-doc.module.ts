import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AngularDocRoutingModule } from './angular-doc-routing.module';
import { FatherComponentComponent } from './father-component/father-component.component';
import { SonComponentComponent } from './son-component/son-component.component';
import { PetsService } from 'src/app/_services/pets/pets.service';


@NgModule({
  declarations: [
    FatherComponentComponent,
    SonComponentComponent
  ],
  imports: [
    CommonModule,
    AngularDocRoutingModule
  ],
  providers: [PetsService]
})
export class AngularDocModule { }
