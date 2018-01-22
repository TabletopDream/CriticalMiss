import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';


import { AppComponent } from './app.component';
import { SvgComponentModule } from './svg-component-module/svg-component.module';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    SvgComponentModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
