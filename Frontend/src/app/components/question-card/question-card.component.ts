import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Question } from '../../models/question';
import axios from 'axios'
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-question-card',
  templateUrl: './question-card.component.html',
  styleUrls: ['./question-card.component.css']
})
export class QuestionCardComponent {
  questionList: Array<Question> = [];
  questionIndex: number = 0;
  @Output() scoreEvent = new EventEmitter<number>();
  optionIndex: any;
  score:number=0;
  startButtonText: string = 'Start';
  baseUrl:string=environment.backendBaseUrl;

  changeSelection(event:any,index:number){
    this.optionIndex = event.target.checked ? index: undefined;
  }
  submitAnswer(){
    console.log('Q Card: ', this.questionIndex);
    if (this.optionIndex==undefined || this.optionIndex==null){
      return;
    }
    if(this.questionIndex < this.questionList.length){
      const answerObj = {
        questionAnswerId: this.questionList[this.questionIndex].questionAnswerId,
        answer: this.questionList[this.questionIndex].options[this.optionIndex].optionText
      };
      console.log(answerObj);
      axios.post(`${environment.backendBaseUrl}/api/QuestionAnswer/checkAnswer`, answerObj).then(res => {
        console.log(res.data)  
        // TODO: score calculate according to answer result
        if(res.data.isAnwserCorrect){
          this.score++;
        }
          
        // next question
        this.optionIndex = null;
        this.questionIndex++;
        if(this.questionIndex == this.questionList.length){
          this.scoreEvent.emit(this.score);
          this.score = 0;
          console.log(this.score);
        }
      });
    }
  }
  retry(){
    this.startButtonText = 'Retry';
    this.getQuestions();
    this.reset();
  }
  stop(){
    this.startButtonText = 'Start';
    this.questionList = [];
    this.reset()
  }
  reset(){
    this.questionIndex = 0;
    this.optionIndex = null;
    this.score = 0;
    this.scoreEvent.emit(-1);
  }
  getQuestions(){
    axios.get(`${environment.backendBaseUrl}/api/QuestionAnswer/getRandomQuestions/3`).then(res => {
      this.questionList = res.data;
    });
  }
}
