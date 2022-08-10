import { Component, OnInit } from '@angular/core';
import {DOCUMENT} from '@angular/common';
import { NavigationEnd, Router } from '@angular/router';

@Component({
  selector: 'nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit {
  primaryUrl: string = "";
  constructor(private router: Router) { }

  ngOnInit() {
    this.router.events.subscribe(event => {
      if(event instanceof NavigationEnd) {
        this.primaryUrl = event.url.split("/")[1];
      }
    });
  }

  redirectTo(url: string) {
    this.router.navigate([url]);
  }
}
