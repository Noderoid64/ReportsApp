import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { materialModules } from './imports/meterial.imports';


@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule,
    ...materialModules
  ],
  exports: [
    ...materialModules
  ]
})
export class SharedModule { }
