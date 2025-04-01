import { CanDeactivateFn } from '@angular/router';
import { UserDetailComponent } from '../Utenti/user-detail/user-detail.component';

export const preventUnsavedChangesGuard: CanDeactivateFn<UserDetailComponent> = (component) => {
  if(component.localEditForm?.dirty) {
    return confirm('Sei sicuro di voler uscire? le informazioni non salvate saranno perse.');
  }
  return true;
};
