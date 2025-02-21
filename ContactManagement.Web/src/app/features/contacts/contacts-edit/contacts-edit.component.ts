import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { provideNativeDateAdapter } from '@angular/material/core';
import { ContactService } from '../contact.service';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmDeleteModalComponent } from '../confirm-delete-modal/confirm-delete-modal.component';

@Component({
  selector: 'app-contacts-edit',
  providers: [provideNativeDateAdapter()],
  imports: [FormsModule, MatButtonModule, MatDatepickerModule, MatFormFieldModule, MatInputModule, MatProgressBarModule],
  templateUrl: './contacts-edit.component.html',
  styleUrl: './contacts-edit.component.scss'
})
export class ContactsEditComponent implements OnInit {
  id: string;
  contact: any;

  constructor(private route: ActivatedRoute,
    private dialog: MatDialog, 
    private router: Router,
    private contactService: ContactService) {
    this.id = this.route.snapshot.paramMap.get('id') ?? '';
  }
  
  ngOnInit() {
    this.contactService.getContactById(this.id).subscribe(res => this.contact = res);
  }

  saveChanges() {
    this.contactService.updateContact(this.contact).subscribe(res => this.navigateToContacts());
  }

  deleteContact() {
    const dialogRef = this.dialog.open(ConfirmDeleteModalComponent, {
      data: {name: `${this.contact.firstName} ${this.contact.lastName}`},
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result === true) {
        this.contactService.deleteContact(this.id).subscribe(res => this.navigateToContacts());
      }
    });
  }

  navigateToContacts() {
    this.router.navigate(['/contacts']);
  }
}
