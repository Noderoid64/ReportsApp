import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class JwtStorageService {

    private readonly TOKEN_KEY = 'token';

    constructor() { }

    public getToken(): string {
        return localStorage.getItem(this.TOKEN_KEY);
    }

    public setToken(token: string): void {
        localStorage.setItem(this.TOKEN_KEY, token);
    }
}