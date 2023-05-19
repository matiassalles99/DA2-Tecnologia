import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-son',
  templateUrl: './son-component.component.html',
  styleUrls: []
})
export class SonComponent implements OnInit {
  @Input() message: string = '';
  @Input() messageProp: string = '';
  @Output() emitterFromSon: EventEmitter<string> = new EventEmitter<string>();

  ngOnInit(): void {
  }

  sendEventToFather() {
    this.emitterFromSon.emit('Esto es un evento desde el hijo');
  }

}
