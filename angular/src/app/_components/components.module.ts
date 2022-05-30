import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SidebarComponent } from './sidebar/sidebar.component';
import { FootbarComponent } from './footbar/footbar.component';
import { NavbarComponent } from './navbar/navbar.component';
import { SimpleTableComponent } from './simple-table/simple-table.component';



@NgModule({
  declarations: [
    SidebarComponent,
    FootbarComponent,
    NavbarComponent,
    SimpleTableComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    SidebarComponent,
    FootbarComponent,
    NavbarComponent,
    SimpleTableComponent]
})
export class ComponentsModule { }
