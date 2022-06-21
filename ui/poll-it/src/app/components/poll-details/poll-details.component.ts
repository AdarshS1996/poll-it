import { Component } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Location } from '@angular/common';
import { PollService } from 'src/app/services/poll.service';

@Component({
  selector: 'app-poll-details',
  templateUrl: './poll-details.component.html',
  styleUrls: ['./poll-details.component.scss']
})
export class PollDetailsComponent {

  pollForm: FormGroup;

  constructor(private formBuilder: FormBuilder,
              private location: Location,
              private pollService: PollService) {
    this.pollForm = this.initializePollForm();
  }

  initializePollForm() {
    return this.formBuilder.group({
      questionTitle: '',
      questionOptions: this.formBuilder.array([
        this.formBuilder.group({
          option: ''
        }),
        this.formBuilder.group({
          option: ''
        })
      ])
    });
  }

  addOption() {
    this.getOptions().push(this.formBuilder.group({
      option: ''
    }));
  }

  getOptions() {
    return this.pollForm.get("questionOptions") as FormArray;
  }

  postPoll()
  {
    this.pollService.postQuestion(this.pollForm.value).subscribe(poll => {
      this.goBack();
    });
  }

  goBack() {
    this.location.back();
  }
}
