import { Routes } from '@angular/router';
import { ContactsListComponent } from './features/contacts/contacts-list/contacts-list.component';
import { ContactsAddComponent } from './features/contacts/contacts-add/contacts-add.component';
import { ContactsEditComponent } from './features/contacts/contacts-edit/contacts-edit.component';

export const routes: Routes = [
    { path: 'contacts', component: ContactsListComponent },
    { path: 'contacts/add', component: ContactsAddComponent },
    { path: 'contacts/edit/:id', component: ContactsEditComponent },
    { path: '',   redirectTo: '/contacts', pathMatch: 'full' }
];
