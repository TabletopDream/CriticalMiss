import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
//import { TestComponentComponent } from './test-component/test-component.component';
import { CriticalMissHttpModule } from '../critical-miss-http/critical-miss-http.module';

@NgModule({
  imports: [
    CommonModule,
    CriticalMissHttpModule
  ],
  //declarations: [TestComponentComponent]
})
export class CriticalMissModule { }
