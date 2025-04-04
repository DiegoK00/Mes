import { inject, Injectable, OnInit, signal } from '@angular/core';
import { Utenti } from '../_models/User';
import { HttpClient, HttpParams } from '@angular/common/http'; 
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UtentiTabellaService {
private http = inject(HttpClient);
  private baseUrl = environment.apiUrl;
  //  public userS = signal<Utenti[] | null>(null);
  public userS = signal<Utenti[]>([]);
  
  constructor() { }

  // getMembers(pageNumber?: number, pageSize?: number) {
  getMembers() {
    let params = new HttpParams();

    // if (pageNumber && pageSize) {
    //   params = params.append('pageNumber', pageNumber);
    //   params = params.append('pageSize', pageSize);
    // }

    // console.log(this.baseUrl + 'Utenti');

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

  getMemberDesc(username: string) {
    return this.http.get<Utenti>(this.baseUrl + 'Utenti/' + username);
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
}
