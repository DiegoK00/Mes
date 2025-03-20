import { Routes } from '@angular/router';
import { HomeComponent } from './home/home/home.component'; 
import { CustomerListComponent } from './Clienti/customer-list/customer-list.component';
import { CommListComponent } from './Commesse/comm-list/comm-list.component';
import { UserDetailComponent } from './Utenti/user-detail/user-detail.component';

export const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'Clienti', component: CustomerListComponent },
  { path: 'Commesse', component: CommListComponent },
  { path: 'user/detail', component: UserDetailComponent },
  { path: 'Utenti', component: UserDetailComponent },
  { path: '**', component: HomeComponent, pathMatch: 'full' },
];
