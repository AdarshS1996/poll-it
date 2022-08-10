import { PollsComponent } from './components/polls/polls.component';
import { NavBarComponent } from './common/nav-bar/nav-bar.component';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HeaderComponent } from './common/header/header.component';
import { CommonModule } from '@angular/common';
import { PollDetailsComponent } from './components/poll-details/poll-details.component';
import { NgxPaginationModule } from 'ngx-pagination';
import { HttpClientModule } from '@angular/common/http';
import { PollService } from './services/poll.service';
import { SearchFilter } from './pipes/search-filter.pipe';
import { PollViewComponent } from './components/poll-view/poll-view.component';
import { VoteSubmitComponent } from './components/vote-submit/vote-submit.component';
import { VoteService } from './services/vote.service';

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    HeaderComponent,
    PollsComponent,
    PollDetailsComponent,
    PollViewComponent,
    VoteSubmitComponent,
    SearchFilter
  ],
  imports: [
    CommonModule,
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    HttpClientModule,
    NgxPaginationModule
  ],
  providers: [
    PollService,
    VoteService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
