import {
  Component,
  HostListener,
  inject,
  input,
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
import { UtentiTabellaService } from '../../_services/utenti-tabella.service';

@Component({
  selector: 'app-user-detail',
  standalone: true,
  imports: [TabsModule, FormsModule],
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
 
  private accountService = inject(AccountService);
  private usersService = inject(UtentiTabellaService);
  private toastr = inject(ToastrService);

  id = input.required<number>();
  utente?: Utenti;

  ngOnInit(): void {
    this.loadMembers();
  }

  loadMembers() {
    this.usersService.getMember(this.id()).subscribe({
      next: (user) => (this.utente = user),
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
