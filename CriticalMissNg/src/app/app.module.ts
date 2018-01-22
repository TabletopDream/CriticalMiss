import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpModule} from '@angular/http';
import {FormsModule} from '@angular/forms';
import { AppComponent } from './app.component';
import {platformBrowserDynamic} from '@angular/platform-browser-dynamic';
import { GameComponent } from './critical-miss-common/game.component';
import { CmGamesHttpService } from './critical-miss-http/cm-games-http.service';
import { CommonModule } from '@angular/common';
import { CriticalMissModule } from './critical-miss-module/critical-miss.module';
import { SvgComponentModule } from './svg-component-module/svg-component.module';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpModule,
    FormsModule,
    CriticalMissModule,
    SvgComponentModule
  ],
  providers: [CmGamesHttpService],
  
  bootstrap: [AppComponent]
})
export class AppModule { }
