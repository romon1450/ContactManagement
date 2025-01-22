import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ContactService {
  private contactsApiUrl = 'http://localhost:5134/api/contacts';
  
  constructor(private http: HttpClient) { }

  getAllContacts(): Observable<any> {
    return this.http.get(this.contactsApiUrl);
  }

  getContactById(id: string): Observable<any> {
    return this.http.get(`${this.contactsApiUrl}/${id}`);
  }

  addContact(contact: any): Observable<any> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    }); 
    return this.http.post(this.contactsApiUrl, contact, {headers: headers});
  }

  updateContact(contact: any): Observable<any> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    }); 
    return this.http.put(`${this.contactsApiUrl}/${contact.id}`, contact, {headers: headers});
  }

  deleteContact(id: string): Observable<any> {
    return this.http.delete(`${this.contactsApiUrl}/${id}`);
  }
}
