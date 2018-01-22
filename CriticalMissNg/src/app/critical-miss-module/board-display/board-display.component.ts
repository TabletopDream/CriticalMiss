import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-board-display',
  templateUrl: './board-display.component.html',
  styleUrls: ['./board-display.component.css']
})
export class BoardDisplayComponent implements OnInit {

  public gameName: string = 'monopoly';

  constructor(activeRoute: ActivatedRoute) { }

  ngOnInit() {
  }

}
