import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { AuthDataDto } from 'src/app/feature/reports/model/dtos/auth-data.dto';

@Injectable({ providedIn: 'root' })
export class JwtTokenRestProvider {
    constructor(private httpClient: HttpClient) { }

    public getToken(email: string, password: string): Observable<AuthDataDto> {
        return this.httpClient.get<AuthDataDto>(environment.serverUrl + 'Auth?email=' + email + '&password=' + password)
            .pipe(tap(val => console.log(val)));
    }
}