import { Component, OnChanges, OnInit } from '@angular/core';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { Polls } from 'src/app/models/polls.model';
import { PollService } from 'src/app/services/poll.service';
import { Location } from '@angular/common';
import { VoteService } from 'src/app/services/vote.service';
import { Vote } from 'src/app/models/vote.model';

@Component({
  selector: 'app-vote-submit',
  templateUrl: './vote-submit.component.html',
  styleUrls: ['./vote-submit.component.scss']
})
export class VoteSubmitComponent implements OnInit {
    poll: Polls = new Polls();
    guid: string = "";
    selectedOptionId: number = 0;

  constructor(private pollService: PollService,
              private router: Router,
              private activatedRoute: ActivatedRoute,
              private location: Location,
              private voteService: VoteService) {}

  ngOnInit(): void {
        this.guid = this.activatedRoute.snapshot.params['guid']; 
        this.pollService.getQuestionById(this.guid).subscribe((question: Polls) => {
            this.poll = question;
        });
  }

  goBack(guid: string) {
    this.router.navigateByUrl("polls/view/" + guid);
  }

  calculateVotePercentage(totalVote: number) {
    return (Number.isNaN(Math.floor((totalVote/this.poll.totalVotes)*100)) 
           ? "0" 
           : Math.floor((totalVote/this.poll.totalVotes)*100)) + "%";
  }

 postVote() {
    if(this.selectedOptionId != 0) {
        let vote = new Vote();
        vote.questionOptionId = this.selectedOptionId;
        this.voteService.postVote(vote).subscribe((vote: Vote) => {
            this.goBack(this.poll.guid);
        });
    }
 }

 shareOnFacebook() {
  window.open(`https://www.facebook.com/sharer/sharer.php?u=${this.router['location']._platformLocation.location.href}`, "_blank");
 }

 shareOnTwitter() {
  window.open(`https://twitter.com/intent/tweet/?text=people%27s%20choice%20Vote%20now%20at%20&url=${this.router['location']._platformLocation.location.href}`, "_blank");
 }
}
