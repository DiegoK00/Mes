import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable, OnInit, signal } from '@angular/core';
import { environment } from '../../environments/environment';
import { Utenti } from '../_models/User';

@Injectable({
  providedIn: 'root',
})
export class UsersService {
  private http = inject(HttpClient);
  private baseUrl = environment.apiUrl;
  //  public userS = signal<Utenti[] | null>(null);
  public userS = signal<Utenti[]>([]);
  
  constructor() { }

  // getMembers(pageNumber?: number, pageSize?: number) {
  getMembers() {
    let params = new HttpParams();

    return this.http.get<Utenti[]>(this.baseUrl + 'Utenti').subscribe({
      next: (member) => {
        // const sortedMembers = member.sort((a, b) => a.Cognome < b.Cognome ? -1 : (a.Cognome > b.Cognome ? 1 : 0));
        // this.userS.set(sortedMembers);
        this.userS.set(member);
        console.log('member :  ' + this.userS());
      },
    });
  }

  getRetrieveMembers() : Utenti[]{
      this.http.get<Utenti[]>(this.baseUrl + 'Utenti').subscribe({
      next: (member) => {
        this.userS.set(member);
        return member;
      },
    });
    return <Utenti[]>([]);
  }

  getMember(id: number) {
    return this.http.get<Utenti>(this.baseUrl + 'Utenti/' + id);
  }

  updateUser(user: Utenti) {
    return this.http.put(this.baseUrl + 'Utenti', user).pipe();
  }

  insertUser(user: Utenti) {
    return this.http.post(this.baseUrl + 'Utenti', user).pipe();
  }

  deleteuser(id: number) {
    return this.http.delete(this.baseUrl + 'Utenti/' + id);
  }

}
