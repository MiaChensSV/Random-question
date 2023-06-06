import { Component, OnInit } from '@angular/core';
import axios from 'axios';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'Frontend';

  questionList:Array<any>=[];
  answerId:number=1;


  constructor(){
    
  }
  
  ngOnInit(){
    this.getQuestions();
  }
  getQuestions(){
    axios.get('http://localhost:3001/api/QuestionAnswer/getRandomQuestions/3').then(res => {
      const question:any = res.data;
      this.questionList=question;
      console.log(this.questionList);
    });
  }
  
  receiveAnswer($event:any){
    this.answerId=$event;
    console.log(this.answerId)
  }
}
