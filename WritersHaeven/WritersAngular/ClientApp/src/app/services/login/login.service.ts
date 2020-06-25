import { Injectable } from '@angular/core';

import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { Account } from './../../models/account';
import { IAccount } from './../../models/iaccount';


@Injectable({
  providedIn: 'root'
})
export class LoginService{

  
  private urlString;
  constructor(protected http: HttpClient) {
   
    this.urlString = 'http://localhost:5000/api/auth';
  }

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };



  login(account): Observable<Account> {
 
    return this.http.post<Account>(this.urlString + '/login', account,this.httpOptions)
      .pipe(map(account => {
        console.log(account);
        if (account != null) {
          console.log("yep!");
          return account;
        }
        else {
          console.log("no:c");
        }
      }), catchError(err => {
        console.log("also no");
        return throwError(
          `Backend returned: ${err.status}`);
      }
      ));
  }



}
