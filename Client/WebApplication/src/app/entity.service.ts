import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Entity } from './models/entity';

@Injectable({
  providedIn: 'root'
})
export class EntityService {

  apiUrl = 'http://localhost:5248/api';
  private httpHeaders: HttpHeaders;

  constructor(private http: HttpClient) {
    this.httpHeaders = new HttpHeaders({
      'X-API-Key': 'cf98f6f0-34dc-4c0f-8eee-3304a85c5ccb'
    });
  }

  getEntities(): Observable<Entity[]> {
    return this.http.get<any[]>(`${this.apiUrl}/entities`, { headers: this.httpHeaders });
  }

  getEntityById(id: string): Observable<Entity> {
    return this.http.get<any>(`${this.apiUrl}/entities/${id}`, { headers: this.httpHeaders });
  }

  addEntity(name: string): Observable<Entity> {
    let entity: Entity = { id: crypto.randomUUID(), name: name };
    return this.http.post<any>(`${this.apiUrl}/entities`, entity, { headers: this.httpHeaders });
  }

  updateEntity(id: string, entity: Entity): Observable<void> {
    return this.http.put<any>(`${this.apiUrl}/entities/${id}`, entity, { headers: this.httpHeaders });
  }

  deleteEntity(id: string): Observable<void> {
    return this.http.delete<any>(`${this.apiUrl}/entities/${id}`, { headers: this.httpHeaders });
  }
}
