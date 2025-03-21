import { Component, inject, OnInit } from '@angular/core';
import { UsersService } from '../../_services/users.service';
import { User } from '../../_models/User';

@Component({
  selector: 'app-user-list',
  standalone: true,
  imports: [],
  templateUrl: './user-list.component.html',
  styleUrl: './user-list.component.css'
})
export class UserListComponent implements OnInit {
  public userService = inject(UsersService);
 userS: User[] = [];
  // pageNumber = 2;
  // pageSize = 5;

  ngOnInit(): void {
    // OLD
    if (this.userService.userS().length === 0) this.loadMembers();
    //if (!this.memberService.paginatedResult()) this.loadMembers();
  }

  loadMembers() {
    // this.memberService.getMembers(this.pageNumber,this.pageSize);

    this.userService.getMembers();
  }

}
