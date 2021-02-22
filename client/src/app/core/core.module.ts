import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CoreRoutingModule } from './core-routing.module';
import { LoginComponent } from './pages/login/login.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RootComponent } from './components/root/root.component';

@NgModule({
  declarations: [
    LoginComponent,
    RootComponent
  ],
  imports: [
    BrowserModule,
    CoreRoutingModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [
    RootComponent
  ]
})
export class CoreModule { }
