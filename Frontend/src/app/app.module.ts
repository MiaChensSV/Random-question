import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { QuestionsComponent } from './components/questions/questions.component';
import { FormsModule } from '@angular/forms';
import { QuestionListComponent } from './components/questionList/questionList.component';

@NgModule({
  declarations: [
    AppComponent,
    QuestionsComponent,
    QuestionListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
  ],
  providers: [
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
