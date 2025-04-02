import {
  Component,
  HostListener,
  inject,
  OnInit,
  ViewChild,
  viewChild,
} from '@angular/core';
import { AccountService } from '../../_services/account.service';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { FormsModule, NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Utenti } from '../../_models/User';
import { UsersService } from '../../_services/users.service';

@Component({
  selector: 'app-user-detail',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './user-detail.component.html',
  styleUrl: './user-detail.component.css',
})
export class UserDetailComponent implements OnInit {
  @ViewChild('editForm') localEditForm?: NgForm;
  @HostListener('window:beforeunload', ['$event']) notify($event: any) {
    if (this.localEditForm?.dirty) {
      $event.returnValue = true;
    }
  }
  utente: Utenti = {
    id: 0,
    username: '',
    password: '',
    token: '',
    nome: '',
    cognome: '',
    description: '',
    photo: '',
  };
  private accountService = inject(AccountService);
  private usersService = inject(UsersService);
  private toastr = inject(ToastrService);

  ngOnInit(): void {
    this.loadMembers();
  }

  loadMembers() {
    const user = this.accountService.currentUser();
    console.log(user);
    if (!user) return;
    this.usersService.getMember(user.username).subscribe({
      next: (member) => (this.utente = member),
    });
  }

  updateMember() {
    this.usersService.updateUser(this.localEditForm?.value).subscribe({
      next: (_) => {
        this.toastr.success('profile update OKOK!!');
        this.localEditForm?.reset(this.utente);
      },
    });
  }
}
