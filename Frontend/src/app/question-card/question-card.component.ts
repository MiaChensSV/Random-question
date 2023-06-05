import { Component, Input, Output, OnInit } from '@angular/core';
import { Question } from '../models/question';
import axios from 'axios'

@Component({
  selector: 'app-question-card',
  templateUrl: './question-card.component.html',
  styleUrls: ['./question-card.component.css']
})
export class QuestionCardComponent implements OnInit{
  @Input() questionList: Array<Question> = [];
  questionIndex: number = 0;
  optionIndex: any;
  answer: any;

  ngOnInit(){
    console.log('QUESTION CARD: ', this.questionList);
  }
  changeSelection(event:any,index:number){
    this.optionIndex = event.target.checked ? index: undefined;
  }
  submitAnswer(){
    if (!this.optionIndex){
      return;
    }
    const answerObj = {
      questionAnswerId: this.questionList[this.questionIndex].questionAnswerId,
      answer: this.questionList[this.questionIndex].options[this.optionIndex].optionText
    };
    console.log(answerObj)
    axios.post('http://localhost:3001/api/QuestionAnswer/checkAnswer', answerObj).then(res => {
      console.log(res.data);
      // TODO: score calculate according to answer result
    });
    if (this.questionIndex < this.questionList.length - 1){
      // next question
      this.optionIndex = null;
      this.questionIndex++;
    } else {
      // todo: return score to parent
    }
  }
}
