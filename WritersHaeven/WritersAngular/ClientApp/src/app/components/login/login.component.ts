import { Component, Inject, OnInit } from '@angular/core';
import {
  FormGroup, FormArray, FormBuilder,
  Validators, ReactiveFormsModule
} from '@angular/forms';
import { LoginService } from '../../services/login/login.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {
  ngOnInit(): void {
     
  }

  constructor(private loginService: LoginService) {
   
  }
  
  submit(username: String, password:String) {
    console.log(username, password);
    //this.loginService.

  }
  
  

}


