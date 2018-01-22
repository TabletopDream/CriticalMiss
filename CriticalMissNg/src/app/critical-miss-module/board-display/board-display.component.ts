import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import 'rxjs/add/operator/switchMap';
import { Observable } from 'rxjs/Observable';
import { Board, BoardItem } from '../../critical-miss-common';

@Component({
  selector: 'app-board-display',
  templateUrl: './board-display.component.html',
  styleUrls: ['./board-display.component.css']
})
export class BoardDisplayComponent implements OnInit {

  public gameName: string;
  public boardId: number;

  constructor(private route: ActivatedRoute,
              private router: Router) { }

  ngOnInit() {
    const gameName = this.route.snapshot.paramMap.get('gameName');
    const boardId = +this.route.snapshot.paramMap.get('boardId');

    this.gameName = gameName;
    this.boardId = boardId;
  }

}
