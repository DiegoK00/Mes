import { Component, inject, input } from '@angular/core';
import { Utenti } from '../../_models/User';
import { RouterLink } from '@angular/router';
import { UsersService } from '../../_services/users.service';
import { ToastrService } from 'ngx-toastr';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-user-card',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './user-card.component.html',
  styleUrl: './user-card.component.css',
})

export class UserCardComponent {
public userService = inject(UsersService);
private toaster = inject(ToastrService);

  utente = input.required<Utenti>();
 
  updateUtente() {
    this.userService.updateUser(this.utente()).subscribe({
      next: () => this.toaster.info('Salvato!')   ,
      error  : (error) => this.toaster.error(error.error),
    })
  }

  clearUtente(id: number) {
    this.userService.getMember(id).subscribe(
      (utente: Utenti) => {
        this.utente().description = utente.description;
        this.utente().cognome = utente.cognome;
        this.utente().nome = utente.nome;
        this.utente().username = utente.username; 
        this.utente().telefono = utente.telefono; 
        this.utente().email = utente.email; 
   }
  );
  }

}
