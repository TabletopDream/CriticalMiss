import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { CmGamesHttpService } from '../../critical-miss-http';
import { Game } from '../../critical-miss-common';
import { CreateGameModalComponent } from '../create-game-modal/create-game-modal.component';

@Component({
  selector: 'app-game-display',
  templateUrl: './game-display.component.html',
  styleUrls: ['./game-display.component.css']
})
export class GameDisplayComponent implements OnInit {

  private gamesList: Array<Game>;

  constructor(private gameService: CmGamesHttpService,
              private modalService: NgbModal) {

  }

  ngOnInit() {
    this.gameService.getGames().then((games: Array<Game>) => {
      this.gamesList = games;
    });
  }

  joinGame(game: Game) {
    alert(game.gameName);
  }

  createGame() {
    const createGameModal = this.modalService.open(CreateGameModalComponent);
    createGameModal.result.then((game: Game) => {
      this.gameService.createGame(game).then((newGame: Game) => {
        this.gamesList.push(newGame);
      });
    }).catch((reason: any) => {
      // Do nothing, user can cancel if they wish
    });
  }
}
