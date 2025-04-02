import { Component, inject } from '@angular/core';
import { UsersService } from '../../_services/users.service';
import { Utenti } from '../../_models/User';
// import { UserCardComponent } from '../user-card/user-card.component';
import { RouterLink } from '@angular/router';
import { routes } from '../../app.routes';

@Component({
  selector: 'app-user-list',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './user-list.component.html',
  styleUrl: './user-list.component.css'
})
export class UserListComponent {

  public userService = inject(UsersService);
  pageNumber = 2;
  pageSize = 5;

  ngOnInit(): void {
    // OLD
    // if (this.memberService.memberS().length === 0) this.loadMembers();
    if (this.userService.userS().length === 0)  this.loadMembers();
    
  }

  loadMembers() {
    // this.userService.getMembers(this.pageNumber,this.pageSize);
    this.userService.getMembers();
  }

}
