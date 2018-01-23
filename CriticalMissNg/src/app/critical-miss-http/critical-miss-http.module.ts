import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CmGamesHttpService } from './cm-games-http.service';
import { CmBoardsHttpService } from './cm-boards-http.service';
import { CmItemsHttpService } from './cm-items-http.service';
import { HttpClientModule } from '@angular/common/http'
import { CmHttpUrlBuilderService } from './cm-http-url-builder.service';

@NgModule({
  imports: [
    CommonModule,
    HttpClientModule
  ],
  declarations: [
  ],
  providers: [
    CmHttpUrlBuilderService,
    CmGamesHttpService,
    CmBoardsHttpService,
    CmItemsHttpService,
  ],
  exports: [
    HttpClientModule
  ]
})
export class CriticalMissHttpModule { }
