import {RouterModule, Routes} from "@angular/router";
import {NgModule} from "@angular/core";
import {InfractionsListComponent} from "./components/infractions-list/infractions-list.component";
import {InfractionsAddComponent} from "./components/infractions-add/infractions-add.component";
import {InfractionsEditComponent} from "./components/infractions-edit/infractions-edit.component";
import {AuthGuard} from "../../guards/auth.guard";

const routes: Routes = [
  {
    path: '',
    component: InfractionsListComponent,
    canActivate: [AuthGuard],
    children: [
      {
        path: 'add',
        component: InfractionsAddComponent
      },
      {
        path: 'edit/:id',
        component: InfractionsEditComponent
      }
    ]
  },
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class InfractionsRoutingModule {}
