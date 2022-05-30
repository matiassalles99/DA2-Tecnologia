import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Pet } from 'src/app/_types/pet';
import { environment } from 'src/environments/environment';
import { PetsEndpoints } from '../endpoints';

@Injectable({
  providedIn: 'root'
})
export class PetsService {

  constructor(private http: HttpClient) { }

  public getPets() : Observable<Pet[]> {
    // TODO: Podemos evitar interpolar base url utilizando interceptors
    return this.http.get<Pet[]>(`${environment.BASE_URL}${PetsEndpoints.GET_ALL_PETS}`);
  }
}
