import { Injectable } from '@angular/core';
import {catchError, tap} from "rxjs/operators";
import {Observable, throwError} from "rxjs";
import {HttpClient, HttpErrorResponse} from "@angular/common/http";
import {IBaseResponse} from "../../../interfaces/baseResponse";
import {IInfractions} from "../interfaces/infractions";
import {environment} from "../../../../environments/environment";
import {Infraction, InfractionsInsertRequest} from "../models/infraction";

@Injectable({
  providedIn: 'root'
})
export class InfractionsService {
  infractionsInsertRequest: InfractionsInsertRequest;
  constructor(private http: HttpClient) {
    this.infractionsInsertRequest = new InfractionsInsertRequest();
  }

  getInfractionsList(pageNumber: number, pageSize: number): Observable<IBaseResponse<IInfractions[]>> {
    return this.http.get<IBaseResponse<IInfractions[]>>(environment.apiUrl + 'infractions', {
      params: {
        pageNumber: pageNumber,
        pageSize: pageSize
      },
    })
      .pipe(tap(), catchError(this.handleError));
  }

  addInfraction(infraction: Infraction): Observable<IBaseResponse<IInfractions>> {
    this.infractionsInsertRequest.infraction = infraction;
    return this.http.post<IBaseResponse<IInfractions>>(environment.apiUrl + 'infractions', this.infractionsInsertRequest)
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
