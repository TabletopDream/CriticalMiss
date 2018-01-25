import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

import { Game } from '../../critical-miss-common';
import { CmGamesHttpService } from '../../critical-miss-http';

@Component({
  selector: 'app-game-list',
  templateUrl: './game-list.component.html',
  styleUrls: ['./game-list.component.css']
})
export class GameListComponent implements OnInit {

  @Input() gamesList: Array<Game>;

  @Output() gameJoin = new EventEmitter<Game>();

  constructor(private gameService: CmGamesHttpService) {

  }

  ngOnInit() {
  }

  joinGame(game: Game) {
    this.gameJoin.emit(game);
  }
}
