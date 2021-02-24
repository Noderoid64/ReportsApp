import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { JwtStorageService } from '../../services/jwt-storage.service';
import { JwtTokenRestProvider } from '../../services/jwt-token-rest-provider.service';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
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
    private jwtTokenStorage: JwtStorageService,
    private router: Router
  ) { }

  public loginButtonPressed(): void {
    // TODO: move to JwtTokenFacade
    if (this.loginFormGroup.valid) {
      const formValue = this.loginFormGroup.value;
      this.jwtTokenProvider.getToken(formValue.emailControl, formValue.passControl)
        .subscribe(res => {
          this.jwtTokenStorage.setToken(res);
          this.router.navigateByUrl('reports/tasks');
        }, error => console.error(error));
    }

  }

}
