import { Injectable } from '@angular/core';
import {HttpClient, HttpErrorResponse} from "@angular/common/http";
import {Observable, throwError} from "rxjs";
import {IBaseResponse} from "../interfaces/baseResponse";
import {environment} from "../../../../environments/environment";
import {catchError, tap} from "rxjs/operators";
import {ICountry} from "../interfaces/country";

@Injectable({
  providedIn: 'root'
})
export class DropdownService {

  constructor(private http: HttpClient) { }

  public getCountryList(): Observable<IBaseResponse<ICountry[]>> {
    return this.http.get<IBaseResponse<ICountry[]>>(environment.apiUrl + 'country')
      .pipe(tap(), catchError(this.handleError));
  }

  private handleError(error: HttpErrorResponse) {
    console.clear();
    console.log(error);
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      errorMessage = `An error occurred: ${error.error.message}`;
    } else {
      errorMessage = `Server returned code: ${error.status}, error message is: ${error.message}`;
    }
    return throwError(errorMessage);
  }
}
