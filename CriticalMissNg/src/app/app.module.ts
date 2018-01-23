import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { RouterModule, Routes } from '@angular/router';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppComponent } from './app.component';
import { SvgComponentModule } from './svg-component-module';
import { CmGamesHttpService } from './critical-miss-http/cm-games-http.service';

import { CriticalMissModule, BoardDisplayComponent } from './critical-miss-module';
import { CriticalMissHttpModule } from './critical-miss-http/critical-miss-http.module';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { GameDisplayComponent } from './critical-miss-module/game-display/game-display.component';

const appRootRoutes: Routes = [
  {
    path: '',
    redirectTo: '/games',
    pathMatch: 'full'
  },
  {
    path: 'games',
    component: GameDisplayComponent
  },
  {
    path: 'games/:gameName/boards/:boardId',
    component: BoardDisplayComponent
  },
  {
    path: '**',
    component: PageNotFoundComponent
  }
]

@NgModule({
  declarations: [
    AppComponent,
    PageNotFoundComponent
  ],
  imports: [
    RouterModule.forRoot(
      appRootRoutes,
      { 
        enableTracing: false,
        useHash: true
      }
    ),
    NgbModule.forRoot(),
    BrowserModule,
    SvgComponentModule,
    CriticalMissModule,
    FormsModule
  ],
  providers: [
    CmGamesHttpService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
