import { Component, OnInit, Input, Output } from '@angular/core';
import { Board, BoardItem } from '../../critical-miss-common';
import { CmBoardsHttpService, CmItemsHttpService, BoardRenderModel } from '../../critical-miss-http';

@Component({
  selector: 'app-svg',
  templateUrl: './svg.component.html',
  styleUrls: ['./svg.component.css']
})
export class SvgComponent implements OnInit {

  @Input() gameName: string;

  public boardModel: Board;
  public boardItems: Array<BoardItem> = [];

  constructor(private httpBoardService: CmBoardsHttpService,
              private httpItemsService: CmItemsHttpService) {
    this.onBoardItemChange = this.onBoardItemChange.bind(this);
    this.onBoardItemDrag = this.onBoardItemDrag.bind(this);
  }

  ngOnInit() {
    this.httpBoardService.getBoard(this.gameName, 1).then((pack: BoardRenderModel) => {
      this.boardModel = pack.board;
      this.boardItems = pack.boardItems;
    });
  }

  public onBoardItemChange(boardItem: BoardItem) {
    this.httpItemsService.updateItem(this.gameName, this.boardModel.localId, boardItem).then((updatedBoard: BoardItem) => {
      var index = this.boardItems.findIndex((val) => {
        return val.localId === updatedBoard.localId;
      });
      this.boardItems[index] = updatedBoard;
    }, (fail) => {
      var index = this.boardItems.findIndex((val) => {
        return val.localId === boardItem.localId;
      });
      this.boardItems[index] = {...this.boardItems[index]};
    });
  }

  public onBoardItemDrag(itemId: number) {

  }
}
