import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../models/user';
import { PaginatedResult, Pagination } from '../models/pagination';
import { map } from 'rxjs/operators';



@Injectable({
  providedIn: 'root'
})
export class RolesService {
  baseUrl = environment.apiUrl + 'roles/';

  constructor(private http: HttpClient) {}

 

  getAllRoles(): Observable<any> {
    return this.http.get(this.baseUrl);
  }

  
}
