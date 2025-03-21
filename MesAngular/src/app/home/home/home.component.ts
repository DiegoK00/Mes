import { Component } from '@angular/core';
// import { RegisterComponent } from '../register/register.component';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

  registerMode = false;
  users: any;

  // nuovo modo?
  registerToggle() {
    this.registerMode = !this.registerMode;
  }

  // vecchio modo?
  cancelRegisterMode(event: boolean) {
    this.registerMode = event;
  }

}
