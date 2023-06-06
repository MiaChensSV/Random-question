import { Component, OnInit,Input } from '@angular/core';

@Component({
  selector: 'app-score-card',
  templateUrl: './score-card.component.html',
  styleUrls: ['./score-card.component.css']
})
export class ScoreCardComponent implements OnInit {
  constructor() { }
  @Input() scoreResult:number=-1;

  ngOnInit() {
  }
  
}
