import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Polls } from 'src/app/models/polls.model';
import { PollService } from 'src/app/services/poll.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-poll-view',
  templateUrl: './poll-view.component.html',
  styleUrls: ['./poll-view.component.scss']
})
export class PollViewComponent implements OnInit {
    poll: Polls = new Polls();
    guid: string = "";

  constructor(private pollService: PollService,
              private router: Router,
              private activatedRoute: ActivatedRoute,
              private location: Location) {}

  ngOnInit(): void {
        this.guid = this.activatedRoute.snapshot.params['guid']; 
        this.pollService.getQuestionById(this.guid).subscribe((question: Polls) => {
            this.poll = question;
        });
  }

  goBack() {
    this.location.back();
  }
}
