import {
  Component,
  HostListener,
  inject,
  OnInit,
  ViewChild,
  viewChild,
} from '@angular/core';
import { Utenti } from '../../_models/User';
import { AccountService } from '../../_services/account.service';
import { UsersService } from '../../_services/users.service';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { FormsModule, NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-member-edit',
  standalone: true,
  imports: [TabsModule, FormsModule],
  templateUrl: './member-edit.component.html',
  styleUrl: './member-edit.component.css',
})
export class MemberEditComponent implements OnInit {
  @ViewChild('editForm') localEditForm?: NgForm;
  @HostListener('window:beforeunload', ['$event']) notify($event: any) {
    if (this.localEditForm?.dirty) {
      $event.returnValue = true;
    }
  }
  member?: Utenti;
  private accountService = inject(AccountService);
  private memberService = inject(UsersService);
  private toastr = inject(ToastrService);

  ngOnInit(): void {
    this.loadMembers();
  }

  loadMembers() {
    const user = this.accountService.currentUser();
    if (!user) return;
    this.memberService.getMember(user.id).subscribe({
      next: (member) => (this.member = member),
    });
  }

  updateMember() {
    this.memberService.updateUser(this.localEditForm?.value).subscribe({
      next: _ => {
        this.toastr.success('profile update OKOK!!');
        this.localEditForm?.reset(this.member);
      }
    });

  }

}
