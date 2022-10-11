import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'vidly-webapp';

  public sayHello(): void {
    console.warn("Hello world");
  }
}
