import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'father-component',
  templateUrl: './father-component.component.html',
  styleUrls: []
})
export class FatherComponent implements OnInit {
  propertyFromFather: string = 'Property from father';
  propertyFromSon: string = '';

  ngOnInit(): void {
  }

  changePropertyFromFather() {
    this.propertyFromFather = 'asdfsdafdsafdaadfs';
  }

  eventFromSon(message: string) {
    this.propertyFromSon = message;
  }
}
