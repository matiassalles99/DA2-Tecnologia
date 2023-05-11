import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PrimerComponenteComponent } from './primer-componente/primer-componente.component';

@NgModule({
  declarations: [PrimerComponenteComponent],
  imports: [CommonModule],
  exports: [PrimerComponenteComponent],
})
export class ComponentsModule {}
