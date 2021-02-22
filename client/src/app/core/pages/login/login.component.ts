import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  public loginFormGroup = new FormGroup({
    emailControl: new FormControl('', [
      Validators.required,
      Validators.email
    ]),
    passControl: new FormControl('', [
      Validators.required
    ])
  });

  constructor() { }

  ngOnInit(): void {
  }

}
