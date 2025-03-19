import { Component, inject } from '@angular/core';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink, RouterLinkActive } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from '../../_services/account.service';
import { User } from '../../_models/User';

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

  model: any | undefined;
  username: string | undefined;
  password: string | undefined;

  login() {
    

    console.info("111111");
    this.model.username = this.username;
    this.model.password = this.password;
    console.info(this.model);
    console.info("22222222");

    this.accountService.login(this.model).subscribe({
      //next: (response) => {
      next: () => {
        // console.log('ok ' + response);
        this.router.navigateByUrl('/Commesse');
      },
      error: (error) => this.toaster.error(error.error),
    });
  }
}
