import { Component } from '@angular/core';;
import { Question } from './models/question';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  score:number=-1;
  constructor(){}

  receiveScore($event:number){
    this.score=$event;
  }
}
