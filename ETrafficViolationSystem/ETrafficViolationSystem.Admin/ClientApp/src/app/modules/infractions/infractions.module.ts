import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {SharedModule} from "../shared/shared.module";
import { InfractionsListComponent } from './components/infractions-list/infractions-list.component';
import { InfractionsAddComponent } from './components/infractions-add/infractions-add.component';
import { InfractionsEditComponent } from './components/infractions-edit/infractions-edit.component';
import {InfractionsRoutingModule} from "./infractions-routing.module";
import {NgxPaginationModule} from "ngx-pagination";
import {FontAwesomeModule} from "@fortawesome/angular-fontawesome";



@NgModule({
  declarations: [
    InfractionsListComponent,
    InfractionsAddComponent,
    InfractionsEditComponent
  ],
    imports: [
        CommonModule,
        SharedModule,
        InfractionsRoutingModule,
        NgxPaginationModule,
        FontAwesomeModule
    ]
})
export class InfractionsModule { }
