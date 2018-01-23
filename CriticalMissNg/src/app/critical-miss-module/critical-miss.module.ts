import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { CriticalMissHttpModule } from '../critical-miss-http/critical-miss-http.module';
import { BoardDisplayComponent } from './board-display/board-display.component';
import { SvgComponentModule } from '../svg-component-module';
import { CmGamesHttpService } from '../critical-miss-http/cm-games-http.service';
import { GameDisplayComponent } from './game-display/game-display.component';
import { GameListComponent } from './game-list/game-list.component';
import { CreateGameModalComponent } from './create-game-modal/create-game-modal.component';

@NgModule({
  imports: [
    CommonModule,
    CriticalMissHttpModule,
    SvgComponentModule,
    RouterModule,
    FormsModule,
    NgbModule
  ],
  declarations: [
    BoardDisplayComponent,
    GameDisplayComponent,
    GameListComponent,
    CreateGameModalComponent
  ],
  exports: [
    BoardDisplayComponent,
    GameDisplayComponent
  ],
  entryComponents: [
    CreateGameModalComponent
  ]
})
export class CriticalMissModule { }
