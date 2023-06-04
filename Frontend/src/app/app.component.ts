import { Component, OnInit } from '@angular/core';
import axios from 'axios';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'Frontend';
  ngOnInit(){
    axios.get('http://localhost:3001/api/QuestionAnswer/getRandomQuestions/3').then(res => {
      console.log(res);
    });
  };
}
