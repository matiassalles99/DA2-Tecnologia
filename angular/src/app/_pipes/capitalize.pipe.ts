import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'capitalize'
})
export class CapitalizePipe implements PipeTransform {

  transform(value: string, suffix: string): string {
    if(value.length == 0) {
      return "Sin valor"
    }
    return value.charAt(0).toUpperCase() + value.slice(1) + suffix;
  }
}
