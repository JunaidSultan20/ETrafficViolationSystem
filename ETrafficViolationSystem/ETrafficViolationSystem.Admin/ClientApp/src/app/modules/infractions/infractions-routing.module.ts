import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule, Routes} from "@angular/router";
import {InfractionsListComponent} from "./components/infractions-list/infractions-list.component";
import {InfractionsEditComponent} from "./components/infractions-edit/infractions-edit.component";
import {InfractionsAddComponent} from "./components/infractions-add/infractions-add.component";

const infractionRoutes: Routes = [
  {
    path: 'list',
    component: InfractionsListComponent
  },
  {
    path: 'add',
    component: InfractionsAddComponent
    //canActivate: [AuthGuard]
  },
  {
    path: 'edit/:id',
    component: InfractionsEditComponent
  }
]

@NgModule({
  imports: [RouterModule.forChild(infractionRoutes)],
  exports: [RouterModule]
})
export class InfractionsRoutingModule { }
