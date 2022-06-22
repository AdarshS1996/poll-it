import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Polls } from 'src/app/models/polls.model';
import { PollService } from 'src/app/services/poll.service';
import { Location } from '@angular/common';
import * as am4core from "@amcharts/amcharts4/core";
import * as am4charts from "@amcharts/amcharts4/charts";

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
            console.log(this.poll);
        });
  }

  goBack() {
    this.location.back();
  }

  calculateVotePercentage(totalVote: number) {
    return (Number.isNaN(Math.floor((totalVote/this.poll.totalVotes)*100)) 
           ? "0" 
           : Math.floor((totalVote/this.poll.totalVotes)*100)) + "%";
  }

  // ngAfterViewInit() {
  //   // Create chart instance
  //   let chart = am4core.create("chartdiv", am4charts.PieChart);

  //   // Create pie series
  //   let series = chart.series.push(new am4charts.PieSeries());
  //   series.dataFields.value = "litres";
  //   series.dataFields.category = "country";

  //   // Add data
  //   chart.data = [{
  //     "country": "Lithuania",
  //     "litres": 501.9
  //   }, {
  //     "country": "Czech Republic",
  //     "litres": 301.9
  //   }, {
  //     "country": "Ireland",
  //     "litres": 201.1
  //   }, {
  //     "country": "Germany",
  //     "litres": 165.8
  //   }, {
  //     "country": "Australia",
  //     "litres": 139.9
  //   }, {
  //     "country": "Austria",
  //     "litres": 128.3
  //   }, {
  //     "country": "UK",
  //     "litres": 99
  //   }, {
  //     "country": "Belgium",
  //     "litres": 60
  //   }, {
  //     "country": "The Netherlands",
  //     "litres": 50
  //   }];

  //   // And, for a good measure, let's add a legend
  //   chart.legend = new am4charts.Legend();

  //   chart.responsive.enabled = true;
  // }
}
