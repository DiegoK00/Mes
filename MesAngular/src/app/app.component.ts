import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { app } from '../../server';
import { HomeComponent } from "./home/home/home.component";
import { NavComponent } from "./home/nav/nav.component";
import { CommonModule, NgFor } from '@angular/common'; 
import { routes } from './app.routes';
import { NgxSpinnerComponent } from 'ngx-spinner';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, NavComponent, RouterOutlet, NgxSpinnerComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  title = 'MesAngular';

  ngOnInit(): void {
    
  }

}
