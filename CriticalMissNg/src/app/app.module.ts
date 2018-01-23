import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

//import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppComponent } from './app.component';
import { SvgComponentModule } from './svg-component-module';
import {HttpModule} from '@angular/http';
import {FormsModule} from '@angular/forms';
import {platformBrowserDynamic} from '@angular/platform-browser-dynamic';
import { GameComponent } from './critical-miss-common/game.component';
import { CmGamesHttpService } from './critical-miss-http/cm-games-http.service';
import { CommonModule } from '@angular/common';

import { RouterModule, Routes } from '@angular/router';
import { CriticalMissModule, BoardDisplayComponent } from './critical-miss-module';
import { CriticalMissHttpModule } from './critical-miss-http/critical-miss-http.module';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';

const appRootRoutes: Routes = [
  // {
  //   path: 'games',
  //   component: GamesDisplayComponent
  // },
  // {
  //   path: '', 
  //   component: GamesDisplayComponent
  // },
  {
    path: '',
    redirectTo: '/games',
    pathMatch: 'full'
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
      { enableTracing: false }
    ),
    //NgbModule.forRoot(),
    BrowserModule,
    SvgComponentModule,
    CriticalMissModule,
    FormsModule
  ],
  providers: [CmGamesHttpService],
  
  bootstrap: [AppComponent]
})
export class AppModule { }
