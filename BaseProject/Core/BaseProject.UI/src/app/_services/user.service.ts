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
export class UserService {
  baseUrl = environment.apiUrl + 'user/';

  constructor(private http: HttpClient) {}

  getUsers(pagination: Pagination): Observable<PaginatedResult<any[]>>{
    
    const paginatedResult: PaginatedResult<User[]> = new PaginatedResult<User[]>();
    let params = new HttpParams(); 

    if (pagination.pageNumber != null && pagination.pageSize != null) {
      params = params.append('pageNumber', pagination.pageNumber.toString());
      params = params.append('pageSize', pagination.pageSize.toString());
    }

    return this.http.get(this.baseUrl , { observe: 'response', params})
    .pipe(
      map(response => {
        paginatedResult.result = response.body['users'];
        const pag = new Pagination();
        pag.pageNumber =  response.body["pageNumber"];
        pag.pageSize = response.body['pageSize'];
        pag.pageTotal = response.body['pageTotal'];
        pag.totalRecords = response.body['totalRecords'];
        paginatedResult.pagination = pag;
        return paginatedResult;
      })
    );
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
