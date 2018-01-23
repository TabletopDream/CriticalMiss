import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SvgBoardItemComponent } from './svg-board-item.component';

describe('SvgBoardItemComponent', () => {
  let component: SvgBoardItemComponent;
  let fixture: ComponentFixture<SvgBoardItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SvgBoardItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SvgBoardItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
