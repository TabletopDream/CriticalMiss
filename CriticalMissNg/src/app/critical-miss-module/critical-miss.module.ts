import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CriticalMissHttpModule } from '../critical-miss-http/critical-miss-http.module';
import { GameComponent } from '../critical-miss-common/game.component';
import { HttpModule } from '@angular/http/src/http_module';
import { CmGamesHttpService } from '../critical-miss-http/cm-games-http.service';

@NgModule({
  imports: [
    CommonModule,
    CriticalMissHttpModule,
    HttpModule
  ],
  declarations: [GameComponent],

  providers:[CmGamesHttpService]
})
export class CriticalMissModule { }
