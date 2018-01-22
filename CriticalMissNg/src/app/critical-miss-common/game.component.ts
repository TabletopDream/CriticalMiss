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
            .getGames().then((res: Array<Game>) => {
                this.gamemodels = res;
            });
    }
    addGame(gm: Game) {
        this.gameservice.createGame(gm)
            .then(gm => {
                this.gamemodels.push(gm);
            });
        // this.gamemodel = new gm('', '');
        // this.gamemodels.push(this.gamemodel);
        // this.isNewRecord = true;
    }
    editGame(gm:Game){
        this.gamemodel=gm;
    }

    loadTemplate(gm: Game) {
        if (this.gamemodel && this.gamemodel.gameName == gm.gameName) {
            return this.editTemplate;
        }
        else {
            return this.readOnlyTemplate;
        }
    }
    saveGame() {
        if (this.isNewRecord) {
            //add NewGame
            this.gameservice.createGame(this.gamemodel).then((gm: Game) => {
                this.gamemodel = gm;
                this.getgames();
            });
            this.isNewRecord = false;
            this.gamemodel = null;
        }
        else {
            this.gameservice.updateGame(this.gamemodel.gameName, this.gamemodel).then((gm: Game) => {
                this.statusMessage = "Game updated Succesfully..";
                this.getgames();
            });
            this.gamemodel = null;
        }
    }
    cancel() {
        this.gamemodel = null;
    }
    deleteGame(gm: Game) {
        this.gameservice.deleteGame(gm.gameName).then((gm: Game) => {
            this.statusMessage = "Game deleated Succesfully..";
            this.getgames();
        });
    }
}