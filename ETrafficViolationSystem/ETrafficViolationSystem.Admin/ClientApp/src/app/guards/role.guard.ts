import { Injectable } from '@angular/core';
import {ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree} from '@angular/router';
import { Observable } from 'rxjs';
import {HelperService} from "../modules/shared/services/helper.service";

@Injectable({
  providedIn: 'root'
})
export class RoleGuard implements CanActivate {
  constructor(private helper: HelperService, private router: Router) {
  }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    const expectedRole = route.data.expectedRole;
    const token = this.helper.getToken();
    const tokenPayload = this.helper.jwtHelper.decodeToken(token);

    if (!this.helper.isAuthenticated() || tokenPayload.role !== expectedRole) {
      this.router.navigate(['login']);
      return false;
    }
    return true;
  }
}
