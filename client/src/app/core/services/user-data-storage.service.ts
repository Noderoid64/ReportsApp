import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class UserDataStorageService {
    constructor() { }

    private userId: number;

    public setUserId(userId: number): void {
        this.userId = userId;
    }

    public getUserId(): number {
        return this.userId;
    }
}