import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse,
} from '@angular/common/http';

import { catchError } from 'rxjs/operators';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Observable, throwError } from 'rxjs';


@Injectable()
export class CustomerHttpInterceptor implements HttpInterceptor {

  constructor(
    private snb: MatSnackBar
  ) { }
  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request)
      .pipe(
        catchError((error: HttpErrorResponse) => {
          return this.handleError(error);
        })
      );
  }
  handleError(error: HttpErrorResponse) {
    let errors = {
      detail: '',
      status: 500,
    };
    if (!error.error) {
      errors.detail = error.message;
      errors.status = error.status;
    } else {
      errors = error.error;
    }
    return throwError(errors);
  }
}
