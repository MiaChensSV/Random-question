import { Component, OnInit,Input } from '@angular/core';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-score-card',
  templateUrl: './score-card.component.html',
  styleUrls: ['./score-card.component.css']
})
export class ScoreCardComponent implements OnInit {
  constructor() { }
  @Input() scoreResult:number=-1;

  ngOnInit() {
    console.log(environment);
  }
  
}
