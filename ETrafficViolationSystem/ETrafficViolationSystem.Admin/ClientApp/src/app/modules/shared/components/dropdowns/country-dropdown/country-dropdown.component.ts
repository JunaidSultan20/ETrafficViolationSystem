import { Component, OnInit } from '@angular/core';
import {ICountry} from "../../../interfaces/country";
import {DropdownService} from "../../../services/dropdown.service";

@Component({
  selector: 'app-country-dropdown',
  templateUrl: './country-dropdown.component.html',
  styleUrls: ['./country-dropdown.component.scss']
})
export class CountryDropdownComponent implements OnInit {
  countryList: ICountry[] = [];
  constructor(private dropdownService: DropdownService) { }

  ngOnInit(): void {
    this.getCountryList();
  }

  getCountryList() {
    this.dropdownService.getCountryList().subscribe({
      next: response => {
        this.countryList = response.result;
      }
    });
  }
}
