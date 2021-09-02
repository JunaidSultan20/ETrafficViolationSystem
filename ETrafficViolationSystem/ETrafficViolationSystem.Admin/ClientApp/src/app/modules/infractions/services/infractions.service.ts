import { Injectable } from '@angular/core';
import {IInfractions} from "../interfaces/infractionDto";
import {HttpClient, HttpErrorResponse, HttpHeaders} from "@angular/common/http";
import {Observable, throwError} from "rxjs";
import {IBaseResponse} from "../../../interfaces/baseResponse";
import {environment} from "../../../../environments/environment";
import {catchError, tap} from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class InfractionsService {

  constructor(private http: HttpClient) { }

  getInfractionsList(pageNumber: number, pageSize: number): Observable<IBaseResponse<IInfractions[]>> {
    return this.http.get<IBaseResponse<IInfractions[]>>(environment.apiUrl + 'infractions', {
      params: {
        pageNumber: pageNumber,
        pageSize: pageSize
      },
    })
      .pipe(tap(), catchError(this.handleError));
  }

  private handleError(error: HttpErrorResponse) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      errorMessage = `An error occurred: ${error.error.message}`;
    } else {
      errorMessage = `Server returned code: ${error.status}, error message is: ${error.message}`;
    }
    return throwError(errorMessage);
  }
}
