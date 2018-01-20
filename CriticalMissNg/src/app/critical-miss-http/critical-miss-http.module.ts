import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CmGamesHttpService } from './cm-games-http.service';
import { CmBoardsHttpService } from './cm-boards-http.service';
import { CmItemsHttpService } from './cm-items-http.service';
import { HttpClientModule } from '@angular/common/http'

@NgModule({
  imports: [
    CommonModule,
    HttpClientModule
  ],
  declarations: [
  ],
  exports: [
    CmGamesHttpService,
    CmBoardsHttpService,
    CmItemsHttpService,
    HttpClientModule
  ]
})
export class CriticalMissHttpModule { }
