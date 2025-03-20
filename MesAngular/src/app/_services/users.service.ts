import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { environment } from '../../environments/environment';
import { User } from '../_models/User';

@Injectable({
  providedIn: 'root',
})
export class UsersService {
  private http = inject(HttpClient);
  baseUrl = environment.apiUrl;
  userS = signal<User[]>([]);

  getMembers(pageNumber?: number, pageSize?: number) {
    let params = new HttpParams();

    if (pageNumber && pageSize) {
      params = params.append('pageNumber', pageNumber);
      params = params.append('pageSize', pageSize);
    }

    return this.http.get<User[]>(this.baseUrl + 'Utenti').subscribe({
      next: (member) => this.userS.set(member),
    });
  }

  getMember(username: string) {
    return this.http.get<User>(this.baseUrl + 'Utenti/' + username);
  }

 
  updateUser(user: User) {
    return this.http.put(this.baseUrl + 'Utenti', user).pipe();
  }

  insertUser(user: User) {
    return this.http.post(this.baseUrl + 'Utenti', user).pipe();
  }
}
