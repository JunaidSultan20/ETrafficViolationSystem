import {AfterViewInit, Component, OnInit} from '@angular/core';
import { faSearch} from "@fortawesome/free-solid-svg-icons";
import {HelperService} from "../../../shared/services/helper.service";

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit, AfterViewInit {
  faSearch = faSearch;
  username: string = '';
  role: string = '';

  constructor(private helper: HelperService) { }

  ngOnInit(): void {
    this.username = this.helper.getLoggedInUserName();
    this.role = this.helper.getLoggedInUserRole();
  }

  ngAfterViewInit(): void {
    let element = document.getElementById('headerSearch')?.children[0];
    element?.classList.add('ficon');
    element = document.getElementById('headerNotification')?.children[0];
    element?.classList.add('ficon');
  }
}
