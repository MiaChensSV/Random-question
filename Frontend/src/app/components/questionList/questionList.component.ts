import { Component, OnInit,Input } from '@angular/core';
import { Question } from 'src/app/models/question';

@Component({
  selector: 'app-questionList',
  templateUrl: './questionList.component.html',
  styleUrls: ['./questionList.component.css']
})
export class QuestionListComponent implements OnInit {
  questionOne:any;

  @Input() questions:Array<Question>=[];

  constructor() {
   
   }

  ngOnInit() {
  }

}
