import { Component, OnInit } from '@angular/core';
import { Input, Output, EventEmitter, OnDestroy, OnChanges, SimpleChanges } from '@angular/core';
import { BoardItem } from '../../critical-miss-common';

@Component({
  selector: '[app-svg-board-item]',
  templateUrl: './svg-board-item.component.html',
  styleUrls: ['./svg-board-item.component.css']
})
export class SvgBoardItemComponent implements OnInit, OnDestroy, OnChanges {
  @Input() boardItem: BoardItem;
  @Output() boardItemUpdate = new EventEmitter<BoardItem>();

  @Input() pixelCount: number;

  @Output() onSelectChange = new EventEmitter<number>();

  public position: {
    xPos: number;
    yPos: number;
  };

  private mousePosition: {
    xPos: number;
    yPos: number;
  } = null;

  constructor() {
    this.handleMouseMove = this.handleMouseMove.bind(this);
  }

  ngOnInit() {
    this.position = {
      xPos: this.boardItem.xPos,
      yPos: this.boardItem.yPos
    }
  }

  ngOnDestroy() {
    //Ensure that the event listener for this component is removed
    document.removeEventListener('mousemove', this.handleMouseMove);
    this.mousePosition = null;
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes.boardItem) {
      this.boardItem = changes.boardItem.currentValue as BoardItem;

      this.position.xPos = this.boardItem.xPos;
      this.position.yPos = this.boardItem.yPos;
    }
  }

  public onMouseDown(event: MouseEvent) {
    this.mousePosition = {
      xPos: event.pageX,
      yPos: event.pageY
    }

    document.addEventListener('mousemove', this.handleMouseMove)

    this.onSelectChange.emit(this.boardItem.localId);
  }

  public onMouseUp(event: MouseEvent) {
    if (this.mousePosition === null) {
      // mousePosition is null only if this element isn't being dragged
      return;
    }

    document.removeEventListener('mousemove', this.handleMouseMove);

    let boardItemChanged = {
      ...this.boardItem,
      xPos: this.position.xPos,
      yPos: this.position.yPos
    }

    this.mousePosition = null;

    this.onSelectChange.emit(this.boardItem.localId);
    this.boardItemUpdate.emit(boardItemChanged);
  }

  private handleMouseMove(event: MouseEvent) {
    const xDiff = this.mousePosition.xPos - event.pageX;
    const yDiff = this.mousePosition.yPos - event.pageY;

    this.mousePosition.xPos = event.pageX;
    this.mousePosition.yPos = event.pageY;

    this.position.xPos = this.position.xPos - xDiff;
    this.position.yPos = this.position.yPos - yDiff;
  }
}
