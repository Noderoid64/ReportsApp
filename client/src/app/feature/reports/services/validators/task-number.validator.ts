import { AbstractControl, AsyncValidatorFn, ValidatorFn } from '@angular/forms';
import { Observable, of } from 'rxjs';
import { finalize, map } from 'rxjs/operators';
import { TasksRestProviderService } from '../tasks-rest-provider.service';

export function taskNumberValidator(taskProvider: TasksRestProviderService, onValidationEnd: () => void): AsyncValidatorFn {

    const pattern = new RegExp('^[0-9]{8}-[0-9]{4}$')

    return (control: AbstractControl): Observable<{ [key: string]: any } | null> => {
        const invalidFormat = !pattern.test(control.value);
        if (!invalidFormat) {
            return taskProvider.isTaskWithTubeNumberExist(control.value)
                .pipe(map(val => {
                    setTimeout(onValidationEnd, 0);
                    if (val === true) {
                        return null;
                    } else {
                        return { alreadyExist: { valie: control.value } };
                    }
                }))
        } else {
            return of({ invalidFormat: { value: control.value } });
        }
    };
}