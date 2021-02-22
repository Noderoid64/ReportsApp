import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({ providedIn: 'root' })
export class JwtTokenRestProvider {
    constructor(private httpClient: HttpClient) { }

    public getToken(email: string, password: string): Observable<string> {
        return this.httpClient.get<string>(environment.serverUrl + 'Auth?email=' + email + '&password=' + password)
            .pipe(tap(val => console.log(val)));
    }
}