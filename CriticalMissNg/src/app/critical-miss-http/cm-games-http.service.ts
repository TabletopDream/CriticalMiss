import { Injectable } from "@angular/core";
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Game } from '../critical-miss-common/game';
import { Observable } from "rxjs/Observable";
import 'rxjs/Rx';

@Injectable()
export class CmGamesHttpService {
  _getGameApi = "http://localhost:49345/api/games";

  constructor(private http: Http) { }

  GetGames(){
    return this.http.get(this._getGameApi).toPromise();
  }

  
  // GetGames(): Observable<Response> {

  //   let header = new Headers({ 'Content-Type': 'application/json' });
  //   let options = new RequestOptions({ headers: header });

  //   return this.http.get(this._getGameApi);

  // }
  addGames(gm: Game){
    let header = new Headers({ 'Content-Type': 'application/json' });
    let options = new RequestOptions({ headers: header });
    return this
      .http
      .post(this._getGameApi, JSON.stringify(gm), options)
  }
  updateGame(id: number, gm: Game): Observable<Response> {
    let header = new Headers({ 'Content-Type': 'application/json' });
    let options = new RequestOptions({ headers: header });
    return this
      .http
      .put(this._getGameApi + `/` + id, JSON.stringify(gm), options)
  }

  deleteGame(id:number){
    return this.http.delete(this._getGameApi+'/'+id);
  }

}
