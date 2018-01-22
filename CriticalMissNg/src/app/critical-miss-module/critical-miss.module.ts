import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CriticalMissHttpModule } from '../critical-miss-http/critical-miss-http.module';
import { BoardDisplayComponent } from './board-display/board-display.component';
import { SvgComponentModule } from '../svg-component-module';
import { RouterModule } from '@angular/router';
import { GameComponent } from '../critical-miss-common/game.component';
import { CmGamesHttpService } from '../critical-miss-http/cm-games-http.service';
import { FormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    CriticalMissHttpModule,
    SvgComponentModule,
    RouterModule,
    FormsModule,
  ],
  declarations: [
    BoardDisplayComponent,
    GameComponent
  ],
  exports: [
    BoardDisplayComponent,
    GameComponent
  ],
})
export class CriticalMissModule { }
