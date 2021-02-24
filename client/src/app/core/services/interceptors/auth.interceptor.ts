import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { JwtStorageService } from '../jwt-storage.service';


@Injectable()
export class AuthInterceptor implements HttpInterceptor {

    constructor(private jwtTokenStorage: JwtStorageService) { }

    public intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if (this.jwtTokenStorage.getToken()) {
            req = req.clone({
                setHeaders: {
                    'Authorization': `Bearer ${this.jwtTokenStorage.getToken()}`,
                },
            });
        }

        console.log(this.jwtTokenStorage.getToken());
        console.log('Opn');

        return next.handle(req);
    }
}