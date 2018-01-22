import { Game } from './game';
import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { CmGamesHttpService } from '../critical-miss-http/cm-games-http.service';
import { Response } from '@angular/http/src/static_response';

@Component({
    selector: 'getgame',
    templateUrl: './getGame.html',
    styleUrls: ['./game.component.css']
})


export class GameComponent implements OnInit {
    rowdata: any[];
    isNewRecord: boolean;
    @ViewChild('readOnlyTemplate') readOnlyTemplate: TemplateRef<any>;
    @ViewChild('editTemplate') editTemplate: TemplateRef<any>;
    gamemodel: Game;
    gamemodels: Array<Game>;

    message: string;
    statusMessage: string;

    constructor(private gameservice: CmGamesHttpService) {
        this.gamemodels = new Array<Game>();
    }
    ngOnInit() {
        this.getgames();
    }
    getgames() {
        this.gameservice
            .GetGames().then(res => {
                this.gamemodel = res.json();
            });
    }
    addGame(Game) {
        this.gamemodel = new Game(0, '', '');
        this.gamemodels.push(this.gamemodel);
        this.isNewRecord = true;
    }

    loadTemplate(gm: Game) {
        if (this.gamemodel && this.gamemodel.gameid == gm.gameid) {
            return this.editTemplate;
        }
        else {
            return this.readOnlyTemplate;
        }
    }
    saveGame() {
        if (this.isNewRecord) {
            //add NewGame
            this.gameservice.addGames(this.gamemodel).subscribe((resp: Response) => {
                this.gamemodel = resp.json(),
                    this.statusMessage = 'Game Added Successfully',
                    this.getgames();
            });
            this.isNewRecord = false;
            this.gamemodel = null;
        }
        else {
            this.gameservice.updateGame(this.gamemodel.gameid, this.gamemodel).subscribe((resp: Response) => {
                this.statusMessage = "Game UPdated Succesfully..",
                    this.getgames();
            });
            this.gamemodel=null;        
        }
    }
    cancel(){
        this.gamemodel=null;
    }
    deleteGame(gm:Game){
        this.gameservice.deleteGame(gm.gameid).subscribe((res:Response)=>{
            this.statusMessage="Game deleated Succesfully..";
            this.getgames();
        });
    }
}