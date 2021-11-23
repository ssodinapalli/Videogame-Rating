import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  apiUrl = 'http://192.168.0.5:5000/api/games';

//   constructor(private http: HttpClient) {
//     login(data: any): Observable<any> {
//   return this.http.post<any>(this.apiUrl + 'login', data)
//     .pipe(
//       tap(_ => this.log('login')),
//       catchError(this.handleError('login', []))
//     )
// }

// Signup(data: any): Observable<any> {
//   return this.http.post<any>(this.apiUrl + 'Signup', data)
//     .pipe(
//       tap(_ => this.log('login')),
//       catchError(this.handleError('login', []))
//     ),
// }

public handleError<T>(operation = 'operation', result?: T) {
  return (error: any): Observable<T> => {

    // TODO: send the error to remote logging infrastructure
    console.error(error); // log to console instead

    // TODO: better job of transforming error for user consumption
    this.log(`${operation} failed: ${error.message}`);

    // Let the app keep running by returning an empty result.
    return of(result as T);
  };
}

/** Log a HeroService message with the MessageService */
private log(message: string) {
  console.log(message);
}
    
  }
function login(data: any, any: any) {
  throw new Error('Function not implemented.');
}

function data(data: any, any: any) {
  throw new Error('Function not implemented.');
}

function Signup(data: any, any: any) {
  throw new Error('Function not implemented.');
}

