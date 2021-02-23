import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { materialModules } from './imports/meterial.imports';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    ...materialModules
  ],
  exports: [
    ReactiveFormsModule,
    ...materialModules
  ]
})
export class SharedModule { }
