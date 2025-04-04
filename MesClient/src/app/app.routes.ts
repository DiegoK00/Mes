// import { Routes } from '@angular/router';

// export const routes: Routes = [];
import { Routes } from '@angular/router';
import { HomeComponent } from './home/home/home.component';
import { CustomerListComponent } from './Clienti/customer-list/customer-list.component';
import { CommListComponent } from './Commesse/comm-list/comm-list.component';
import { UserDetailComponent } from './Utenti/user-detail/user-detail.component';
import { UserListComponent } from './Utenti/user-list/user-list.component';
import { authGuard } from './_services/auth.guard';

export const routes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [authGuard],
    children: [
      { path: 'Clienti', component: CustomerListComponent },
      { path: 'Commesse', component: CommListComponent },
      { path: 'Utente/:id', component: UserDetailComponent },
      { path: 'Utenti', component: UserListComponent },

      // {path: 'member/edit', component: MemberEditComponent, canDeactivate: [preventUnsavedChangesGuard]},
      // {path: 'admin', component:AdminPanelComponent, canActivate: [adminGuard]}
    ],
  },

  { path: '**', component: HomeComponent, pathMatch: 'full' },
];
