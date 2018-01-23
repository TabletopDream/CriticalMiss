import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

import { Game } from '../../critical-miss-common';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-create-game-modal',
  templateUrl: './create-game-modal.component.html',
  styleUrls: ['./create-game-modal.component.css']
})
export class CreateGameModalComponent implements OnInit {

  game: Game;

  constructor(public activeModal: NgbActiveModal) { }

  ngOnInit() {
    this.game = {
      gameName: "",
      password: ""
    };
  }

  submitGame() {
    console.log(this.game);
    this.activeModal.close(this.game);
  }

}
