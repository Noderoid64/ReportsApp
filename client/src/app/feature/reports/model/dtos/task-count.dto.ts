import { Task } from '../task.model';

export interface TaskCountDto {
    tasks: Task[];
    taskCount: number;
}