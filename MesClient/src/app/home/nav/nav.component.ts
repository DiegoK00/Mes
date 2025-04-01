import { Component, inject, NgModule, input } from '@angular/core';
import { AccountService } from '../../_services/account.service';
import { Router, RouterLink, RouterLinkActive } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Utenti } from '../../_models/User';
import { TitleCasePipe } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';

@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [FormsModule,     BsDropdownModule,     RouterLink,
    RouterLinkActive],
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css'
})
export class NavComponent {
  accountService = inject(AccountService);
  private router = inject(Router);
  private toaster = inject(ToastrService);

  // currentUser = signal<Utenti | null>(null);
  // currentUser = input.required<Utenti>;

  modello: Utenti = {
    id: 0,
    username: '',
    password: '',
    token: 'tt',
    nome: 'nn',
    cognome: 'cc'
  };

  login() {
    
    // console.trace(this.model);

    this.accountService.login(this.modello).subscribe({
      next: () => {
        this.router.navigateByUrl('/Utenti');
        // this.currentUser = utente;
      },
      // era doppiamente intercettato!!!
      // error: (error) => this.toaster.error(error.error),
      
    });
  }
  logout() {
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }

  
}

// @NgModule({
//   declarations: [
//     // other components
//   ],
//   imports: [
//     // other modules
//     FormsModule
//   ]
// })
// export class NavModule { }
