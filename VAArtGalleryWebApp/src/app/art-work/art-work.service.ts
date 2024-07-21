import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ArtWorks } from './models';
import pt  from '@angular/common/locales/pt';

@Injectable({
  providedIn: 'root'
})
export class ArtWorkService {
  //private baseUrl = 'https://localhost:7042/api/art-works';
  private baseUrl = 'http://localhost:5184/api/art-works';
  constructor(private http: HttpClient) { }

  getWorksOnDisplay(id: string): Observable<ArtWorks[]> {
    return this.http.get<ArtWorks[]>(`${this.baseUrl}/${id}`);
  }

  deleteArtWork(id: string):Observable<Boolean>{
    return this.http.delete<Boolean>(`${this.baseUrl}/${id}`);
  }
}
