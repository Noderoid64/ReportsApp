import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class JwtStorageService {

    private token: string;

    constructor() { }

    public getToken(): string {
        return this.token;
    }

    public setToken(token: string): void {
        this.token = token;
    }
}