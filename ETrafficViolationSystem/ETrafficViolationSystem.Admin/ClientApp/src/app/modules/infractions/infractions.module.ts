import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InfractionsComponent } from './components/infractions/infractions.component';
import { InfractionsAddComponent } from './components/infractions-add/infractions-add.component';
import { InfractionsListComponent } from './components/infractions-list/infractions-list.component';
import { InfractionsEditComponent } from './components/infractions-edit/infractions-edit.component';
import {RouterModule} from "@angular/router";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {SharedModule} from "../shared/shared.module";
import {FontAwesomeModule} from "@fortawesome/angular-fontawesome";
import { InfractionsRoutingModule } from './infractions-routing.module';
import {NgxPaginationModule} from "ngx-pagination";
import {NgxSpinnerModule} from "ngx-spinner";



@NgModule({
  declarations: [
    InfractionsComponent,
    InfractionsAddComponent,
    InfractionsListComponent,
    InfractionsEditComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule,
    ReactiveFormsModule,
    FontAwesomeModule,
    FormsModule,
    InfractionsRoutingModule,
    NgxPaginationModule,
    NgxSpinnerModule
  ]
})
export class InfractionsModule { }
