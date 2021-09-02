import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {AuthenticationDto} from "../../../../models/authentication-dto";
import { HelperService } from "../../../shared/services/helper.service";
import {AccountService} from "../../services/account.service";
import {StatusCode} from "../../../shared/enums/statusCode";
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

  constructor(private accountService: AccountService, private helper: HelperService,
              private notificationService: NotificationService, private router: Router) {
    this.authenticationDto = new AuthenticationDto();
  }

  ngOnInit(): void {
  }

  login() {
    if (this.loginFormGroup.valid) {
      this.authenticationDto.Email = this.loginFormGroup.controls.username.value;
      this.authenticationDto.Password = this.loginFormGroup.controls.password.value;
      this.accountService.login(this.authenticationDto).subscribe({
        next: response => {
          if (response.statusCode == StatusCode.Ok && response.isSuccessful) {
            this.helper.setToken(response.result);
            this.router.navigate(['dashboard']);
          }
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

  showToastr() {
  }
}
