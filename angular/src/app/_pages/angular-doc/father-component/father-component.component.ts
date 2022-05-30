import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-father-component',
  templateUrl: './father-component.component.html',
  styleUrls: ['./father-component.component.css']
})
export class FatherComponentComponent implements OnInit {
  propFromFather: string = 'Message from prop from father';
  helloFromSonProp: string = '';
  constructor() { }

  ngOnInit(): void {
  }

  helloFromSon(message: string) {
    this.helloFromSonProp = message;
  }
}
