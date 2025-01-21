import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ContactService } from '../contact.service';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatTableModule } from '@angular/material/table';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-contacts-list',
  imports: [CommonModule, MatButtonModule, MatIconModule, MatProgressBarModule, MatTableModule, RouterModule],
  templateUrl: './contacts-list.component.html',
  styleUrl: './contacts-list.component.scss'
})
export class ContactsListComponent implements OnInit {
  contacts: any[] = [];
  displayedColumns: string[] = ['firstName', 'lastName', 'email', 'phoneNumber', 'birthDate'];
  isLoading: boolean = false;

  constructor(private contactService: ContactService) { }

  ngOnInit() {
    this.isLoading = true;
    this.contactService.getAllContacts().subscribe(res => {
      this.contacts = res;
      this.isLoading = false;
    });
  }
}
