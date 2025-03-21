import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { app } from '../../server';
import { HomeComponent } from "./home/home/home.component";
import { NavComponent } from "./home/nav/nav.component";
import { CommonModule, NgFor } from '@angular/common'; 
import { routes } from './app.routes';
import { NgxSpinnerComponent } from 'ngx-spinner';
import { AccountService } from './_services/account.service';
import { UserListComponent } from "./Utenti/user-list/user-list.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, NavComponent, RouterOutlet, NgxSpinnerComponent, UserListComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  title = 'MesAngular';
  private accountService= inject(AccountService);


  ngOnInit(): void {
    // this.setCurrentUser();
  }
  
  setCurrentUser(){
    const userString = localStorage.getItem('user');
    if (!userString) return;
    const user = JSON.parse(userString);
    this.accountService.currentUser.set(user);
  }

}
