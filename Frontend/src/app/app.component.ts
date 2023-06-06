import { Component, OnInit, Input } from '@angular/core';
import axios from 'axios';
import { Question } from './models/question';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'Frontend';
  score:number=-1;
  questionList:Question[] = [];
  isStarted: boolean = false;
  questionIndexxxxx: number = 0;

  constructor(){

  }

  ngOnInit(){

  }
  // getQuestions(){
  //   axios.get('http://localhost:3001/api/QuestionAnswer/getRandomQuestions/3').then(res => {
  //     const question:any = res.data;
  //     this.questionList=question;
  //   });
  // }

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
