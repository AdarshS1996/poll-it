import { Component } from '@angular/core';
import { DOCUMENT } from '@angular/common';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'polls',
  templateUrl: './polls.component.html',
  styleUrls: ['./polls.component.scss']
})
export class PollsComponent {

  public pollForm: FormGroup;

  constructor(private formBuilder: FormBuilder) {
    this.pollForm = this.formBuilder.group({
      question: '',
      options: this.formBuilder.array([ this.createOptions() ])
    });
  }

  createOptions(): FormGroup {
    return this.formBuilder.group({
      option:''
    });
 }

  onSubmit(): void {
    // Call the API here to create a question
  
  }

  addAddress(): void {
    this.pollForm.get('options')?.value.push(this.createOptions());
  }

  get addressControls() {
    console.log(this.pollForm.value)
    return "";
  }

  getOptions() {
    console.log(this.pollForm.get('options'))
    return (this.pollForm.get('options') as FormArray).controls;
  }
}
