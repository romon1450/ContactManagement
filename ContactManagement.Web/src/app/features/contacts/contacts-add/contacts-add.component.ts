import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { provideNativeDateAdapter } from '@angular/material/core';
import { ContactService } from '../contact.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-contacts-add',
  providers: [provideNativeDateAdapter()],
  imports: [FormsModule, MatButtonModule, MatDatepickerModule, MatFormFieldModule, MatInputModule],
  templateUrl: './contacts-add.component.html',
  styleUrl: './contacts-add.component.scss'
})
export class ContactsAddComponent {
  contact: any = {
    birthDate: '',
    email: '',
    firstName: '',
    lastName: '',
    phoneNumber: ''
  };

  constructor(private contactService: ContactService, private router: Router) { }

  addContact() {
    this.contactService.addContact(this.contact).subscribe(res => this.navigateToContacts());
  }

  navigateToContacts() {
    this.router.navigate(['/contacts']);
  }
}
