import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { CmGamesHttpService } from '../../critical-miss-http';
import { Game } from '../../critical-miss-common';
import { CreateGameModalComponent } from '../create-game-modal/create-game-modal.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-game-display',
  templateUrl: './game-display.component.html',
  styleUrls: ['./game-display.component.css']
})
export class GameDisplayComponent implements OnInit {

  public gamesList: Array<Game>;

  constructor(private gameService: CmGamesHttpService,
              private modalService: NgbModal,
              private router: Router) {

  }

  ngOnInit() {
    this.gameService.getGames().then((games: Array<Game>) => {
      this.gamesList = games;
    });
  }

  joinGame(game: Game) {
    this.router.navigate(['/games', game.gameName, 'boards', 1]);
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
