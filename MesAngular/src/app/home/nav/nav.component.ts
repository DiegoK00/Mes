import { Component, inject } from '@angular/core';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink, RouterLinkActive } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from '../../_services/account.service';
import { Utenti } from '../../_models/User';
import { TitleCasePipe } from '@angular/common';

@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [
    FormsModule,     BsDropdownModule,     RouterLink,
    RouterLinkActive, TitleCasePipe
  ],
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css',
})
export class NavComponent {
  accountService = inject(AccountService);
  private router = inject(Router);
  private toaster = inject(ToastrService);

  model: Utenti = {
    Id: 0,
    Username: '',
    Password: '',
    Token: 'tt',
    Nome: 'nn',
    Cognome: 'cc'
  };

  login() {
    
    // console.trace(this.model);

    this.accountService.login(this.model).subscribe({
      next: () => {
        this.router.navigateByUrl('/Commesse');
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
