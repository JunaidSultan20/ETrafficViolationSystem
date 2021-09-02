import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CountryDropdownComponent } from './components/country-dropdown/country-dropdown.component';
import {ToasterComponent} from "./components/toaster/toaster.component";
import {ToastrModule} from "ngx-toastr";
import { PaginationComponent } from './components/pagination/pagination.component';
import {NgxPaginationModule} from "ngx-pagination";
import {FormsModule} from "@angular/forms";

@NgModule({
  declarations: [
    CountryDropdownComponent,
    ToasterComponent,
    PaginationComponent
    ],
  exports: [
    ToasterComponent,
    CountryDropdownComponent,
    PaginationComponent
  ],
    imports: [
        CommonModule,
        ToastrModule.forRoot(),
        NgxPaginationModule,
        FormsModule,
    ]
})
export class SharedModule { }
