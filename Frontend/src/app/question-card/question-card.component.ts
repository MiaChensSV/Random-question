import { Component, Input, Output, EventEmitter,OnInit } from '@angular/core';
import { Question } from '../models/question';
import axios from 'axios'

@Component({
  selector: 'app-question-card',
  templateUrl: './question-card.component.html',
  styleUrls: ['./question-card.component.css']
})
export class QuestionCardComponent implements OnInit{
  @Input() questionList: Array<Question> = [];
  @Output() scoreEvent = new EventEmitter<number>()
  questionIndex: number = 0;
  optionIndex: any;
  score:number=0;

  ngOnInit(){
  }
  changeSelection(event:any,index:number){
    this.optionIndex = event.target.checked ? index: undefined;
  }
  submitAnswer(){
    if (this.optionIndex==undefined || this.optionIndex==null){
      return;
    }
    const answerObj = {
      questionAnswerId: this.questionList[this.questionIndex].questionAnswerId,
      answer: this.questionList[this.questionIndex].options[this.optionIndex].optionText
    };
    console.log(answerObj)
    axios.post('http://localhost:3001/api/QuestionAnswer/checkAnswer', answerObj).then(res => {
    console.log(res.data)  
    // TODO: score calculate according to answer result
      if(res.data.isAnwserCorrect){
        this.score+=1;
      }
      if (this.questionIndex < this.questionList.length - 1){
        // next question
        this.optionIndex = null;
        this.questionIndex++;
  
      } else {
        // todo: return score to parent
        this.scoreEvent.emit(this.score);        
      }
    });
    
    
  }
}
