import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Task } from '../model/task.model';
import { environment } from 'src/environments/environment';

@Injectable({ providedIn: 'root' })
export class TasksRestProviderService {
    constructor(private httpClient: HttpClient) { }

    public getTasks(take: number, skip: number, taskNumber: string): Observable<Task[]> {
        return this.httpClient.get<Task[]>(
            environment.serverUrl +
            'tasks?take=' + take +
            '&skip=' + skip +
            '&taskNumber='
        );
    }

}