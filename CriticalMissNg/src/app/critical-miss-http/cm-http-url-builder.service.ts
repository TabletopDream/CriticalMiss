import { Injectable } from '@angular/core';

@Injectable()
export class CmHttpUrlBuilderService {

  private baseUrl: string = 'http://localhost:3000/api';

  constructor() { }

  public getGamesCollectionUrl(): string {
    return this.baseUrl + '/games';
  }

  public getGameUrl(gameName: string): string {
    return this.getGamesCollectionUrl() + '/' + gameName;
  }

  public getBoardsCollectionUrl(gameName: string): string {
    return this.getGameUrl(gameName) + '/boards';
  }

  public getBoardUrl(gameName: string, boardId: number): string {
    return this.getBoardsCollectionUrl(gameName) + '/' + boardId;
  }

  public getItemsCollectionurl(gameName: string, boardId: number): string {
    return this.getBoardUrl(gameName, boardId) + '/items';
  }

  public getItemUrl(gameName: string, boardId: number, itemId: number): string {
    return this.getItemsCollectionurl(gameName, boardId) + '/' + itemId;
  }
}
