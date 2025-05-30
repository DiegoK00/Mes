import { HttpClient } from '@angular/common/http';
import { inject, Injectable, signal} from '@angular/core';
import { Utenti } from '../_models/User';
import { environment } from '../../environments/environment';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  private http = inject(HttpClient);
  baseUrl = environment.apiUrl;
  // currentUser = signal<Utenti | null>(null);
  // currentUser = input.required<any>;
  currentUser = signal<Utenti | null>(null);

  // public nomeutente: string = '';

  login(modello: any) {
    // console.log(this.baseUrl + 'account/login');
    // console.log(model);
    return this.http.post<Utenti>(this.baseUrl + 'account/login', modello).pipe(
      map((user) => {
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
            console.log(user.nome);

          // this.currentUser.update(() => user);
          this.currentUser.set(user);
        }
        
      })
    );
  }

  register(model: any) {
    return this.http
      .post<Utenti>(this.baseUrl + 'account/register', model)
      .pipe(
        map((user) => {
          if (user) {
            localStorage.setItem('user', JSON.stringify(user));
            this.currentUser.set(user);
          }
        })
      );
  }

  logout() {
    localStorage.removeItem('user');
    this.currentUser.set(null);
  }
}
