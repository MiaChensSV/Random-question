import { Component } from '@angular/core';;
import { Question } from './models/question';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Frontend';
  score:number=-1;
  questionList:Question[] = [];
  isStarted: boolean = false;
  questionIndexxxxx: number = 0;

  constructor(){

  }

  receiveScore($event:number){
    this.score=$event;
    this.isStarted = false;
  }
  receiveQuestionList($event: Question[]){
    this.questionList=$event;
    this.isStarted = true;
    this.questionIndexxxxx = 0;
    console.log(this.questionIndexxxxx);
  }
  receiveQuestionIndex($event: number){
    this.questionIndexxxxx = $event;
  }
}
