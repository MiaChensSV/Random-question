import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
<<<<<<< HEAD
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
=======

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
>>>>>>> 1903e39e6e37d655d9093f3e801a5bb23ee60a55
  bootstrap: [AppComponent]
})
export class AppModule { }
