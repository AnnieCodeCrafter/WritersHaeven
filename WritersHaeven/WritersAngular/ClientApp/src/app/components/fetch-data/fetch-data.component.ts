import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IAccount } from './../../models/iaccount';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public account: IAccount[];


  constructor(http: HttpClient) {
    http.get<IAccount[]>('http://localhost:5000/api/auth').subscribe(result => {
      this.account = result;
    }, error => console.error(error));
  }
}


