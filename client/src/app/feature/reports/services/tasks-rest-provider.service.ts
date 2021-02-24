import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Task } from '../model/task.model';
import { environment } from 'src/environments/environment';
import { share } from 'rxjs/operators';
import { TaskCountDto } from '../model/task-count.dto';

@Injectable({ providedIn: 'root' })
export class TasksRestProviderService {
    constructor(
        private httpClient: HttpClient
    ) { }

    // TODO merge 'getTasks' and 'getTaskCount' into sigle request

    public getTasks(take: number, skip: number, taskNumber: string | undefined): Observable<TaskCountDto> {
        return this.httpClient.get<TaskCountDto>(
            environment.serverUrl +
            'tasks?take=' + take +
            '&skip=' + skip + (taskNumber ?
                '&taskNumber=' + taskNumber : '')
        ).pipe(share());
    }

    public addTask(task: Task): Observable<any> {
        return this.httpClient.put<Observable<any>>(
            environment.serverUrl +
            'tasks/add',
            task
        );
    }

    public isTaskWithTubeNumberExist(taskNumber: string): Observable<boolean> {
        return this.httpClient.get<boolean>(
            environment.serverUrl + 'tasks/validate?taskNumber=' + taskNumber
        );
    }

}