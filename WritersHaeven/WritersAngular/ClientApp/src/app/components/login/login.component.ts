import { Component, Inject, OnInit } from '@angular/core';
import {
  FormGroup, FormArray, FormBuilder,
  Validators, ReactiveFormsModule
} from '@angular/forms';
import { LoginService } from '../../services/login/login.service';
import { Account } from './../../models/account';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {

  account: Account


  ngOnInit(): void {
  
     
  }

  constructor(private loginService: LoginService) {
   
  }
  
  submit(username: string, password:string) {
    console.log(username, password);
    if (username != null && password != null) {
      this.account = new Account(username, password);
      this.loginService.login(this.account);
    }


  }
  
  

}


