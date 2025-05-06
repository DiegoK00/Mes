import {
  Component,
  HostListener,
  inject,
  input,
  ViewChild,
} from '@angular/core';
import { Utenti } from '../../_models/User';
import { RouterLink } from '@angular/router';
import { UsersService } from '../../_services/users.service';
import { ToastrService } from 'ngx-toastr';
import { FormsModule, NgForm } from '@angular/forms';

@Component({
  selector: 'app-user-card',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './user-card.component.html',
  styleUrl: './user-card.component.css',
})
export class UserCardComponent {
  @ViewChild('editForm') localEditForm?: NgForm;
  @HostListener('window:beforeunload', ['$event']) notify($event: any) {
    if (this.localEditForm?.dirty) {
      $event.returnValue = true;
    }
  }

  public userService = inject(UsersService);
  private toaster = inject(ToastrService);

  utente = input.required<Utenti>();

  updateUtente() {
    console.log(this.utente().token == null);
    if (this.utente().token == null) this.utente().token = '';

    console.log(this.utente());
    this.userService.updateUser(this.utente()).subscribe({
      next: () => this.toaster.info('Salvato!'),
      error: (error) => this.toaster.error(error.error),
    });
  }

  clearUtente(id: number) {
    console.log('clear');
    this.userService.getMember(id).subscribe((utente: Utenti) => {
      this.utente().description = utente.description;
      this.utente().cognome = utente.cognome;
      this.utente().nome = utente.nome;
      this.utente().username = utente.username;
      this.utente().telefono = utente.telefono;
      this.utente().email = utente.email;
      this.utente().indirizzo = utente.indirizzo;
      this.utente().localita = utente.localita;
      this.utente().regione = utente.regione;
      this.utente().provincia = utente.provincia;
      this.utente().nazione = utente.nazione;
      if (this.localEditForm) this.localEditForm.reset(this.utente);
    });
  }
}
