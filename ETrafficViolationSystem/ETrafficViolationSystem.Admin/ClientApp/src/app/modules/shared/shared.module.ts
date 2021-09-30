import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginationComponent } from './components/pagination/pagination.component';
import { ToasterComponent } from './components/toaster/toaster.component';
import { CountryDropdownComponent } from './components/dropdowns/country-dropdown/country-dropdown.component';
import {ToastrModule} from "ngx-toastr";
import {NgxPaginationModule} from "ngx-pagination";
import {FormsModule} from "@angular/forms";
import { PrefixPipe } from './pipes/prefix.pipe';

@NgModule({
  declarations: [
    PaginationComponent,
    ToasterComponent,
    CountryDropdownComponent,
    PrefixPipe
  ],
  imports: [
    CommonModule,
    ToastrModule.forRoot(),
    NgxPaginationModule,
    FormsModule
  ],
    exports: [
        PaginationComponent,
        ToasterComponent,
        CountryDropdownComponent,
        PrefixPipe
    ]
})
export class SharedModule { }
