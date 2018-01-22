import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpModule} from '@angular/http';
import {FormsModule} from '@angular/forms';
import { AppComponent } from './app.component';
import {platformBrowserDynamic} from '@angular/platform-browser-dynamic';
import { GameComponent } from './critical-miss-common/game.component';
import { CmGamesHttpService } from './critical-miss-http/cm-games-http.service';
import { CommonModule } from '@angular/common/src/common_module';


@NgModule({
  declarations: [
    AppComponent, GameComponent
  ],
  imports: [
    BrowserModule,HttpModule, FormsModule
  ],
  providers: [CmGamesHttpService],
  
  bootstrap: [AppComponent]
})
export class AppModule { }
