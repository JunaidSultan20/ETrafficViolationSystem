import { Component, OnInit } from '@angular/core';
import { faHome } from "@fortawesome/free-solid-svg-icons";
import { faEnvelope, faListAlt } from '@fortawesome/free-regular-svg-icons';
import { faListUl, faCar } from "@fortawesome/free-solid-svg-icons";

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {
  faHome = faHome;
  faEnvelope = faEnvelope;
  faListUl = faListUl;
  faCar = faCar;

  constructor() { }

  ngOnInit(): void {
  }

}
