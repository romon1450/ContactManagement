import { Routes } from '@angular/router';
import { ContactsListComponent } from './features/contacts/contacts-list/contacts-list.component';
import { ContactsAddComponent } from './features/contacts/contacts-add/contacts-add.component';

export const routes: Routes = [
    { path: 'contacts', component: ContactsListComponent },
    { path: 'contacts/add', component: ContactsAddComponent },
    { path: '',   redirectTo: '/contacts', pathMatch: 'full' }
];
