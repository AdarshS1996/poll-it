import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Polls } from 'src/app/models/polls.model';
import { PollService } from 'src/app/services/poll.service';

@Component({
  selector: 'app-polls',
  templateUrl: './polls.component.html',
  styleUrls: ['./polls.component.scss']
})
export class PollsComponent implements OnInit {
  p: number = 1;
  search: string = "";
  polls: Polls[] = [];

  constructor(private pollService: PollService,
              private router: Router,
              private activatedRoute: ActivatedRoute) {}

  ngOnInit(): void {
    this.pollService.getQuestions().subscribe(polls => {
      this.polls = polls;
    });
  }

  navigateToCreate() {
    this.router.navigateByUrl('polls/create');
  }

  navigateToView(guid: string) {
    this.router.navigateByUrl("polls/view/" + guid);
  }
}
