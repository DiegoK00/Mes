import { Component, inject } from '@angular/core';
import { UsersService } from '../../_services/users.service';
import { Utenti } from '../../_models/User';
// import { UserCardComponent } from '../user-card/user-card.component';
import { RouterLink } from '@angular/router';
import { routes } from '../../app.routes';
import { UserCardComponent } from '../user-card/user-card.component';

@Component({
  selector: 'app-user-list',
  standalone: true,
  imports: [ UserCardComponent],
  templateUrl: './user-list.component.html',
  styleUrl: './user-list.component.css',
})
export class UserListComponent {


  public userService = inject(UsersService);
  utente: Utenti = {
    id: 0,
    username: '',
    password: '',
    token: '',
    nome: '',
    cognome: '',
    description: '',
    photo: '',
    email: '',
    telefono:'',
  };
  pageNumber = 2;
  pageSize = 5;

  ngOnInit(): void {
    // OLD
    // if (this.memberService.memberS().length === 0) this.loadMembers();
    if (this.userService.userS().length === 0) this.loadMembers();
  }

  loadMembers() {
    // this.userService.getMembers(this.pageNumber,this.pageSize);
    this.userService.getMembers();
  }

  loadUtente(id:number){
   this.userService.getMember(id).subscribe(
      (utente: Utenti) => {
        this.utente = utente;
   });
  }
  deleteUtente(id:number) { 

    console.log('DEL ' + id);
  //     this.userService.getMember(id).subscribe(
  //     (utente: Utenti) => {
  //       this.utente = utente;
  //  });
  }
}
