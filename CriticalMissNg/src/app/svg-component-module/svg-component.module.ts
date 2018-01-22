import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SvgBoardItemComponent } from './svg-board-item/svg-board-item.component';
import { CriticalMissHttpModule } from '../critical-miss-http';

@NgModule({
  imports: [
    CommonModule,
    CriticalMissHttpModule
  ],
  declarations: [
    SvgBoardItemComponent
  ]
})
export class SvgComponentModule { }
