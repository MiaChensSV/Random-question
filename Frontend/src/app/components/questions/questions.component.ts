import { Component, OnInit,Input,Output,EventEmitter } from '@angular/core';
import { Question } from 'src/app/models/question';

@Component({
  selector: 'app-questions',
  templateUrl: './questions.component.html',
  styleUrls: ['./questions.component.css']
})

export class QuestionsComponent implements OnInit {


  selectedIndex:any;
  @Input() questions:Array<Question>=[];
  @Output() choiceEvent = new EventEmitter<any>();

  constructor() {

   }


  ngOnInit() {

  }

  changeSelection(event:any,index:number){
    this.selectedIndex = event.target.checked ? index: undefined;
  }
  sendAnswer(){
    this.choiceEvent.emit(this.selectedIndex);
  }
}
