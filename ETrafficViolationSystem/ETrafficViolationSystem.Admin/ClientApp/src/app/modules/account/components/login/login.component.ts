import { Component, OnInit } from '@angular/core';
import {StatusCode} from "../../../shared/enums/statusCode";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {AuthenticationDto} from "../../models/authentication";
import {AccountService} from "../../services/account.service";
import {HelperService} from "../../../shared/services/helper.service";
import {NotificationService} from "../../../shared/services/notification.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  loginFormGroup: FormGroup = new FormGroup({
    username: new FormControl('', [Validators.required]),
    password: new FormControl('', [Validators.required])
  });
  private authenticationDto: AuthenticationDto;
  isComplete: boolean;
  isDisabled: boolean;
  loginButtonDisplayText: string;

  constructor(private accountService: AccountService, private helper: HelperService,
              private notificationService: NotificationService, private router: Router) {
    this.authenticationDto = new AuthenticationDto();
    this.isComplete = true;
    this.isDisabled = false;
    this.loginButtonDisplayText = 'Sign in';
  }

  ngOnInit(): void {
  }

  login() {
    if (this.loginFormGroup.valid) {
      this.isComplete = false;
      this.isDisabled = true;
      this.loginButtonDisplayText = 'Loading';
      this.authenticationDto.Email = this.loginFormGroup.controls.username.value;
      this.authenticationDto.Password = this.loginFormGroup.controls.password.value;
      this.accountService.login(this.authenticationDto).subscribe({
        next: response => {
          if (response.statusCode == StatusCode.Ok && response.isSuccessful) {
            this.helper.setToken(response.result.token, response.result.refreshToken);
            this.router.navigate(['dashboard']);
          } else if (response.statusCode == StatusCode.Unauthorized) {
            this.isComplete = true;
            this.isDisabled = false;
            this.loginButtonDisplayText = 'Sign in';
          }
        },
        complete: () => {
          this.isComplete = true;
          this.isDisabled = false;
          this.loginButtonDisplayText = 'Sign in';
        },
        error: () => {
          this.isComplete = true;
          this.isDisabled = false;
          this.loginButtonDisplayText = 'Sign in';
        }
      });
    }
  }

  logout() {
    // @ts-ignore
    this.accountService.logout(this.helper.getToken()).subscribe({
      next: response => {
        if (response.statusCode == StatusCode.Ok) {
          this.helper.clearLocalStorage();
        }
      }
    });
  }
}
