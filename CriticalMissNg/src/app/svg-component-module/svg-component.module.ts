import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SvgBoardItemComponent } from './svg-board-item/svg-board-item.component';
import { CriticalMissHttpModule } from '../critical-miss-http';
import { SvgComponent } from './svg/svg.component';

@NgModule({
  imports: [
    CommonModule,
    CriticalMissHttpModule
  ],
  exports: [
    SvgComponent
  ],
  declarations: [
    SvgComponent,
    SvgBoardItemComponent
  ]
})
export class SvgComponentModule { }
