import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { JwtStorageService } from '../../services/jwt-storage.service';
import { JwtTokenRestProvider } from '../../services/jwt-token-rest-provider.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  public loginFormGroup = new FormGroup({
    emailControl: new FormControl('admin@gmail.com', [
      Validators.required,
      Validators.email
    ]),
    passControl: new FormControl('admin', [
      Validators.required
    ])
  });

  constructor(
    private jwtTokenProvider: JwtTokenRestProvider,
    private jwtTokenStorage: JwtStorageService
  ) { }

  public loginButtonPressed(): void {
    // TODO: move to JwtTokenFacade
    if (this.loginFormGroup.valid) {
      const formValue = this.loginFormGroup.value;
      this.jwtTokenProvider.getToken(formValue.emailControl, formValue.passControl)
        .subscribe(res => {
          this.jwtTokenStorage.setToken(res);
        }, error => console.error(error));
    }

  }

}
