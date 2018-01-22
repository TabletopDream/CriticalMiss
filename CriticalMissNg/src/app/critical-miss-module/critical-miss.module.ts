import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CriticalMissHttpModule } from '../critical-miss-http/critical-miss-http.module';
import { GameComponent } from '../critical-miss-common/game.component';
import { CmGamesHttpService } from '../critical-miss-http/cm-games-http.service';
import { FormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    CriticalMissHttpModule
  ],
  declarations: [GameComponent],

  exports:[GameComponent],

  providers:[CmGamesHttpService]
})
export class CriticalMissModule { }
