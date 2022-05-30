import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-son-component',
  templateUrl: './son-component.component.html',
  styleUrls: ['./son-component.component.css']
})
export class SonComponentComponent implements OnInit {
  @Input() message: string = '';
  @Input() messageProp: string = '';
  @Output() helloFromSonProp: EventEmitter<string> = new EventEmitter<string>();

  constructor() { }

  ngOnInit(): void {
  }

  helloFromSon() {
    this.helloFromSonProp.emit('Hello from son');
  }
}
