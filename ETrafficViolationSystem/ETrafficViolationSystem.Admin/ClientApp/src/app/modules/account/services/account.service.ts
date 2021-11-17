import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {RefreshTokenDto} from "../models/refreshToken";
import {Observable} from "rxjs";
import {IBaseResponse} from "../../shared/interfaces/baseResponse";
import {ILoginDto} from "../interfaces/login";
import {AuthenticationDto} from "../models/authentication";
import {environment} from "../../../../environments/environment";
import {IRefreshTokenDto} from "../interfaces/refreshToken";

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  refreshTokenDto: RefreshTokenDto | undefined;

  constructor(private http: HttpClient) { }

  login(authenticationDto: AuthenticationDto) : Observable<IBaseResponse<ILoginDto>> {
    return this.http.post<IBaseResponse<ILoginDto>>(environment.apiUrl + 'account/login', {
      authenticationDto: authenticationDto
    });
  }

  logout(token: string) {
    return this.http.post<IBaseResponse<object>>(environment.apiUrl + 'account/logout', {
      token: token
    });
  }

  refreshToken(token: string, refreshToken: string): Observable<IBaseResponse<IRefreshTokenDto>> {
    this.refreshTokenDto = new RefreshTokenDto(token, refreshToken);
    return this.http.post<IBaseResponse<IRefreshTokenDto>>(environment.apiUrl + 'account/refresh', {
      refreshTokenDto: this.refreshTokenDto
    });
  }
}
