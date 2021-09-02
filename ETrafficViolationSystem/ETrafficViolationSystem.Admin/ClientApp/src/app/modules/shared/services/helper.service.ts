import { Injectable } from '@angular/core';
import {JwtHelperService} from "@auth0/angular-jwt";
import {ILoginDto} from "../../../interfaces/loginDto";

@Injectable({
  providedIn: 'root'
})
export class HelperService {
  isAuthorized: boolean = false;
  jwtHelper: JwtHelperService;

  constructor() {
    this.jwtHelper = new JwtHelperService();
  }

  setToken(loginDto: ILoginDto): void {
    localStorage.setItem('accessToken', loginDto.token);
    localStorage.setItem('refreshToken', loginDto.refreshToken);
  }

  getToken(): string {
    // @ts-ignore
    return localStorage.getItem('accessToken');
  }

  getRefreshToken(): string {
    // @ts-ignore
    return localStorage.getItem('refreshToken');
  }

  clearLocalStorage(): void {
    localStorage.clear();
  }

  getLoggedInUserId(): number {
    const decodedToken = this.jwtHelper.decodeToken(this.getToken());
    return decodedToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'];
  }

  getLoggedInUserRole(): string {
    const decodedToken = this.jwtHelper.decodeToken(this.getToken());
    return decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
  }

  getLoggedInUserName(): string {
    const decodedToken = this.jwtHelper.decodeToken(this.getToken());
    return decodedToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'];
  }

  isTokenExpired(): boolean {
    return this.jwtHelper.isTokenExpired(this.getToken())
  }

  isAuthenticated(): boolean {
    if (this.getToken() !== null && !this.isTokenExpired()) {
      return true;
    }
    return false;
  }
}
