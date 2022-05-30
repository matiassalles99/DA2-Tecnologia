import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { UsersTableComponent } from './users-table/users-table.component';
import { ComponentsModule } from 'src/app/_components/components.module';


@NgModule({
  declarations: [
    UsersTableComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    ComponentsModule
  ]
})
export class AdminModule { }
