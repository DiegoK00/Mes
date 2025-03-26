import { Component, inject, OnInit } from '@angular/core';
import { UnsubscriptionError } from 'rxjs';
import { Utenti } from '../../_models/User';
import { UsersService } from '../../_services/users.service';

@Component({
  selector: 'app-user-detail',
  standalone: true,
  imports: [],
  templateUrl: './user-detail.component.html',
  styleUrl: './user-detail.component.css'
})
export class UserDetailComponent {

}
