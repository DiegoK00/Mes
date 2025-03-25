import { Component, inject, OnInit } from '@angular/core';
import { UsersService } from '../../_services/users.service';
import { User } from '../../_models/User';

@Component({
  selector: 'app-user-list',
  standalone: true,
  imports: [],
  templateUrl: './user-list.component.html',
  styleUrl: './user-list.component.css',
})
export class UserListComponent implements OnInit {
  public userService = inject(UsersService);
  private userS: User[] = [];
  // pageNumber = 2;
  // pageSize = 5;

  async ngOnInit(): Promise<void> {
    // OLD
    if (this.userService.userS()?.length === 0) await this.loadMembers();
    console.log('result: ' + this.userService.userS()?.length);
    // console.log(this.userService.userS()[0].Cognome);
   
    //  new
    //if (!this.memberService.paginatedResult()) this.loadMembers();
  }

  loadMembers() {
    // this.memberService.getMembers(this.pageNumber,this.pageSize);
    console.log('loadMembers');
    this.userService.getMembers();
  }
}
