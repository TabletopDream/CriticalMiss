import { Board } from "../critical-miss-common/board";
import { BoardItem } from "../critical-miss-common/board-item";

export interface BoardRenderModel {
    board: Board;
    boardItems: Array<BoardItem>;
}
