import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Movie } from 'src/app/_types/movie';
import { environment } from 'src/environments/environment';
import { MovieEndpoints } from '../endpoints';

@Injectable({
  providedIn: 'root'
})
export class MovieService {

  constructor(private http: HttpClient) { }

  public getAllMovies() : Observable<Movie[]> {
    return this.http.get<Movie[]>(`${environment.BASE_URL}${MovieEndpoints.GET_ALL_MOVIES}`);
  }
}
