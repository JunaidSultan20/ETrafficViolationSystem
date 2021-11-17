import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';
import { HelperService } from "../modules/shared/services/helper.service";

@Injectable()
export class JwtInterceptor implements HttpInterceptor {

  constructor(private helper: HelperService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    if (this.helper.getToken()) {
      request = request.clone({
        headers : request.headers.set('Authorization', `Bearer ${ this.helper.getToken() }`)
      });
    }

    if (!request.headers.has('Content-Type')) {
      request = request.clone({
        headers: request.headers.set('Content-Type', 'application/json')
      });
    }

    request = request.clone({
      headers: request.headers.set('Accept', 'application/json')
    });

    return next.handle(request);
  }
}
