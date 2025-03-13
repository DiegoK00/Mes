import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { app } from '../../server';
import { HomeComponent } from "./home/home/home.component";
import { NavComponent } from "./home/nav/nav.component";
import { CommonModule, NgFor } from '@angular/common'; 

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [HomeComponent, NavComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'MesAngular';

  ngOnInit(): void {
    
  }
}
