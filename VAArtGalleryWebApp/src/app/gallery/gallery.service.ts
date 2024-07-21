import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, Observable } from 'rxjs';
import { Gallery } from './models';

@Injectable({
  providedIn: 'root'
})
export class GalleryService {
  //private baseUrl = 'https://localhost:7042/api/art-galleries';
  private baseUrl = 'http://localhost:5184/api/art-galleries';
  constructor(private http: HttpClient) { }

  getGalleries(): Observable<Gallery[]> {
    return this.http.get<Gallery[]>(`${this.baseUrl}`);
  }

  getGalleryById(id: string): Observable<Gallery> {
    return this.http.get<Gallery>(`${this.baseUrl}/${id}`);
  }

  addGallery(name: string, city: string, manager: string): Observable<Boolean> {
    let gallery = {name, city, manager};
    console.log(gallery);
    var headers = new HttpHeaders({
      "Content-Type": "application/json",
      "Accept": "application/json",
      "charset": "utf-8"
    });
    return this.http.post<Boolean>(this.baseUrl, gallery, { headers: headers });
  }

  editGallery(id: string, name: string, city: string, manager: string){
    
    var headers = new HttpHeaders({
      "Content-Type": "application/json",
      "Accept": "application/json",
      "charset": "utf-8"
    });

    return this.http.put(this.baseUrl, JSON.stringify({
      id: id,
      name: name,
      city: city,
      manager: manager
      }), { headers: headers });
  }

  removeGallery(id: string): Observable<Boolean> {
    return this.http.delete<Boolean>(`${this.baseUrl}/${id}`);
  }
}
