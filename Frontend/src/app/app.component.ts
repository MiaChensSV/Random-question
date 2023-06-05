import { Component, OnInit } from '@angular/core';
import axios from 'axios';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'Frontend';
<<<<<<< HEAD

  questionList:Array<any>=[];
  answerId:number=1;


  constructor(){
    
  }
  
  ngOnInit(){
    axios.get('http://localhost:3001/api/QuestionAnswer/getRandomQuestions/3').then(res => {
      const question:any = res.data;
      this.questionList=question;
    });
  };

  
  receiveAnswer($event:any){
    this.answerId=$event;
    console.log(this.answerId)
  }
=======
  ngOnInit(){
    axios.get('http://localhost:3001/api/QuestionAnswer/getRandomQuestions/3').then(res => {
      console.log(res);
    });
  };
>>>>>>> 1903e39e6e37d655d9093f3e801a5bb23ee60a55
}
