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
    return this.http.get<any[]>(this.contactsApiUrl);
  }

  addContact(contact: any): Observable<any> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    }); 
    return this.http.post(this.contactsApiUrl, contact, {headers: headers});
  }
}
