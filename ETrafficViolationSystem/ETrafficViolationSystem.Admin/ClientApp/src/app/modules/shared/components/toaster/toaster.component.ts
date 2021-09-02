import {Component, Input, OnInit} from '@angular/core';

@Component({
  selector: 'app-toaster',
  templateUrl: './toaster.component.html',
  styleUrls: ['./toaster.component.scss']
})
export class ToasterComponent implements OnInit {
  displayToast: boolean = true;
  constructor() { }

  ngOnInit(): void {
  }

  show(): void {
    this.displayToast = true;
  }
}
