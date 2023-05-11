import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PrimerComponenteComponent } from './primer-componente/primer-componente.component';
import { TextInputComponent } from './text-input/text-input.component';

@NgModule({
  declarations: [PrimerComponenteComponent, TextInputComponent],
  imports: [CommonModule],
  exports: [PrimerComponenteComponent, TextInputComponent],
})
export class ComponentsModule {}
