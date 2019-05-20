import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../models/user';
import { map } from 'rxjs/operators';
import { UserFilter } from '../models/UserFilters';
import { PagedResult } from '../models/pagination';



@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl = environment.apiUrl + 'user/';

  constructor(private http: HttpClient) {}

  getUsers(fitlers: UserFilter) : Observable<PagedResult<any[]>> {
    let params = new HttpParams();
    const paginatedResult: PagedResult<any[]> = new PagedResult<any[]>();
    params = params.append('pageNumber', fitlers.pageNumber.toString());
    params = params.append('pageSize', fitlers.pageSize.toString());
    params = params.append('email', fitlers.email);
    return this.http.get(this.baseUrl , { observe: 'response', params})
    .pipe(
      map(response => {
          paginatedResult.filters.pageSize = response.body['pageSize'];
          paginatedResult.filters.pageNumber = response.body['pageNumber'];
          paginatedResult.filters.totalRecords = response.body['totalRecords'];
          paginatedResult.entity = response.body['users'];
          return paginatedResult;
      }));
  }

  getUserById(id): Observable<User> {
    return this.http.get<User>(this.baseUrl + id);
  }

  updateUser( user: User) {
    return this.http.put(this.baseUrl, user);
  }

  deleteUser( id) {
    return this.http.delete(this.baseUrl + id);
  }

}
