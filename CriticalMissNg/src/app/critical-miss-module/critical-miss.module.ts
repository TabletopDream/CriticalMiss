import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CriticalMissHttpModule } from '../critical-miss-http/critical-miss-http.module';
import { BoardDisplayComponent } from './board-display/board-display.component';
import { SvgComponentModule } from '../svg-component-module';
import { RouterModule } from '@angular/router';

@NgModule({
  imports: [
    CommonModule,
    CriticalMissHttpModule,
    SvgComponentModule,
    RouterModule
  ],
  declarations: [
    BoardDisplayComponent
  ],
  exports: [
    BoardDisplayComponent
  ]
})
export class CriticalMissModule { }
