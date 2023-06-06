import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Question } from 'src/app/models/question';
import axios from 'axios'
@Component({
  selector: 'app-button-card',
  templateUrl: './button-card.component.html',
  styleUrls: ['./button-card.component.css']
})
export class ButtonCardComponent implements OnInit {

  @Output() questionListEvent = new EventEmitter<Question[]>();
  @Input() isStarted: boolean = false;
  buttonText = 'Start';

  constructor() { }

  ngOnInit() {
  }
  start(){
    this.buttonText = 'Retry';
    axios.get('http://localhost:3001/api/QuestionAnswer/getRandomQuestions/3').then(res => {
      this.questionListEvent.emit(res.data);
      console.log(res.data);
    });
  }
}
