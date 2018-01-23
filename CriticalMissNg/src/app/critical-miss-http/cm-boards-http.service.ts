import { Injectable } from '@angular/core';
import { Board } from '../critical-miss-common';
import { HttpClient } from '@angular/common/http';
import { BoardRenderModel } from './board-render-model';
import { CmHttpUrlBuilderService } from './cm-http-url-builder.service';

@Injectable()
export class CmBoardsHttpService {

  constructor(private httpClient: HttpClient, private urlBuilder: CmHttpUrlBuilderService) { }

  public getBoards(gameName: string): Promise<Array<Board>> {
    var connString = this.urlBuilder.getBoardsCollectionUrl(gameName);

    return this.httpClient.get(connString).toPromise() as Promise<Array<Board>>;
  }

  public getBoard(gameName: string, boardId: number): Promise<BoardRenderModel> {
    var connString = this.urlBuilder.getBoardUrl(gameName, boardId);

    return this.httpClient.get(connString).toPromise() as Promise<BoardRenderModel>;
  }

  public createBoard(gameName: string, board: Board): Promise<Board> {
    var connString = this.urlBuilder.getBoardsCollectionUrl(gameName);

    return this.httpClient.post(connString, board).toPromise() as Promise<Board>;
  }

  public updateBoard(gameName: string, board: Board): Promise<Board> {
    var connString = this.urlBuilder.getBoardUrl(gameName, board.localId);

    return this.httpClient.put(connString, board).toPromise() as Promise<Board>;
  }

  public deleteBoard(gameName: string, boardId: number): Promise<any> {
    var connString = this.urlBuilder.getBoardUrl(gameName, boardId);

    return this.httpClient.delete(connString).toPromise();
  }
}
