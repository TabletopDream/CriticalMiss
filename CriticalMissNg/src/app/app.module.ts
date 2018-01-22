import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppComponent } from './app.component';
import { SvgComponentModule } from './svg-component-module';

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
    NgbModule.forRoot(),
    BrowserModule,
    SvgComponentModule,
    CriticalMissModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
