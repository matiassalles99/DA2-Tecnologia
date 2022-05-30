import { Component, OnInit } from '@angular/core';
import { PetsService } from 'src/app/_services/pets/pets.service';

@Component({
  selector: 'app-father-component',
  templateUrl: './father-component.component.html',
  styleUrls: ['./father-component.component.css']
})
export class FatherComponentComponent implements OnInit {
  propFromFather: string = 'Dynamic Message from Father ';
  helloFromSonProp: string = '';

  constructor(private petService: PetsService) { }

  ngOnInit(): void {
  }

  helloFromSon(message: string) {
    this.helloFromSonProp = message;
  }
  
  public changeMessageProp() {
    this.propFromFather = 'Dynamic Message from Father Changed';
  }

  public sendMessageToBackend() {
    this.petService.getPets().subscribe(pets => {
      console.log(pets);
    }, error => {
      console.error(error)
    })
  }
}
