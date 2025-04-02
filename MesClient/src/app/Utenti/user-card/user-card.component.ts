import { Component, input } from '@angular/core';
import { Utenti } from '../../_models/User';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-user-card',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './user-card.component.html',
  styleUrl: './user-card.component.css'
})
export class UserCardComponent {
  utente = input.required<Utenti>();

}
