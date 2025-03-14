import { Component, inject } from '@angular/core';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink, RouterLinkActive } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from '../../_services/account.service';

@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [FormsModule, BsDropdownModule, RouterLink, RouterLinkActive],
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css',
})
export class NavComponent {
  accountService = inject(AccountService);
  private router = inject(Router);
  private toaster = inject(ToastrService);

  model: any;

  login() {
    this.accountService.login(this.model).subscribe({
      //next: (response) => {
      next: () => {
        // console.log('ok ' + response);
       this.router.navigateByUrl('/Commesse')
      },
      error: error =>this.toaster.error(error.error),
    });
  }
}
