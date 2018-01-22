import { Injectable } from '@angular/core';
import { Game } from '../critical-miss-common';
import { HttpClient } from '@angular/common/http';
import { CmHttpUrlBuilderService } from './cm-http-url-builder.service';

@Injectable()
export class CmGamesHttpService {

  private apiCollectionURL: string = 'http://localhost:3000/api/games';

  constructor(private httpClient: HttpClient, private urlBuilder: CmHttpUrlBuilderService) { }

  public getGames(): Promise<Array<Game>> {
    var connString = this.urlBuilder.getGamesCollectionUrl();

    return this.httpClient.get(connString).toPromise() as Promise<Array<Game>>;
  }

  public getBoard(gameName: string): Promise<Game> {
    var connString = this.urlBuilder.getGameUrl(gameName);

    return this.httpClient.get(connString).toPromise() as Promise<Game>;
  }

  public createGame(gameModel: Game): Promise<Game> {
    var connString = this.urlBuilder.getGamesCollectionUrl();

    return this.httpClient.post(connString, gameModel).toPromise() as Promise<Game>;
  }

  public updateGame(gameName: string, gameModel: Game): Promise<Game> {
    var connString = this.urlBuilder.getGameUrl(gameName);

    return this.httpClient.put(connString, gameModel).toPromise() as Promise<Game>;
  }

  public deleteGame(gameName: string): Promise<any> {
    var connString = this.urlBuilder.getGameUrl(gameName);

    return this.httpClient.delete(connString).toPromise();
  }
}
