import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BoardItem } from '../critical-miss-common/board-item';
import { CmHttpUrlBuilderService } from './cm-http-url-builder.service';

@Injectable()
export class CmItemsHttpService {

  constructor(private httpClient: HttpClient, private urlBuilder: CmHttpUrlBuilderService) { }

  public getItems(gameName: string, boardId: number): Promise<Array<BoardItem>> {
    var connString = this.urlBuilder.getItemsCollectionurl(gameName, boardId);

    return this.httpClient.get(connString).toPromise() as Promise<Array<BoardItem>>;
  }

  public getItem(gameName: string, boardId: number, itemId: number): Promise<BoardItem> {
    var connString = this.urlBuilder.getItemUrl(gameName, boardId, itemId);

    return this.httpClient.get(connString).toPromise() as Promise<BoardItem>;
  }

  public createItem(gameName: string, boardId: number, item: BoardItem): Promise<BoardItem> {
    var connString = this.urlBuilder.getItemsCollectionurl(gameName, boardId);

    return this.httpClient.post(connString, item).toPromise() as Promise<BoardItem>;
  }

  public updateItem(gameName: string, boardId: number, item: BoardItem): Promise<BoardItem> {
    var connString = this.urlBuilder.getItemUrl(gameName, boardId, item.localId);

    return this.httpClient.put(connString, item).toPromise() as Promise<BoardItem>;
  }

  public deleteItem(gameName: string, boardId: number, itemId: number): Promise<any> {
    var connString = this.urlBuilder.getItemUrl(gameName, boardId, itemId);

    return this.httpClient.delete(connString).toPromise();
  }
}
