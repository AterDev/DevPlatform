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

  constructor() { }
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
      detail: error.error,
      status: 500,
    };

    switch (error.status) {
      case 404:
        errors.detail = error.error;
        break;
      case 500:
        errors.detail = error.message;
        errors.status = error.status;
        break;
      default:
        errors = error.error;
        break;
    }
    console.log(errors);

    return throwError(errors);
  }
}
