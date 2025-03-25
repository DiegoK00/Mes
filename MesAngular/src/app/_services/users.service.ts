import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { environment } from '../../environments/environment';
import { User } from '../_models/User';

@Injectable({
  providedIn: 'root',
})
export class UsersService {
  private http = inject(HttpClient);
  private baseUrl = environment.apiUrl;
  userS = signal<User[] | null>(null);

  // getMembers(pageNumber?: number, pageSize?: number) {
  getMembers() {
    let params = new HttpParams();

    // if (pageNumber && pageSize) {
    //   params = params.append('pageNumber', pageNumber);
    //   params = params.append('pageSize', pageSize);
    // }

    // console.log(this.baseUrl + 'Utenti');

    return   this.http.get<User[]>(this.baseUrl + 'Utenti').subscribe({
      next: (member) => {
        // const sortedMembers = member.sort((a, b) => a.Cognome < b.Cognome ? -1 : (a.Cognome > b.Cognome ? 1 : 0));
        // this.userS.set(sortedMembers);
        this.userS.set(member);
        console.log('member :  ' + member.length);
        console.log(member[2]);
      },
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
