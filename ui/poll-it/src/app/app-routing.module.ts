import { PollsComponent } from './components/polls/polls.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PollDetailsComponent } from './components/poll-details/poll-details.component';
import { PollViewComponent } from './components/poll-view/poll-view.component';
import { VoteSubmitComponent } from './components/vote-submit/vote-submit.component';

const routes: Routes = [
  {
    path: 'polls',
    component: PollsComponent
  },
  {
    path: 'polls/create',
    component: PollDetailsComponent
  },
  {
    path: 'polls/edit/:guid',
    component: PollDetailsComponent
  },
  {
    path: 'polls/view/:guid',
    component: PollViewComponent
  },
  {
    path: 'polls/vote/:guid',
    component: VoteSubmitComponent
  },
  {
    path: '**',
    component: PollsComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
