import { NgModule } from '@angular/core';
import {RouterModule, Routes} from "@angular/router";
import {CarsComponent} from "./components/cars/cars.component";
import {AuthGuard} from "../../guards/auth.guard";

const routes: Routes = [
  {
    path: 'cars',
    component: CarsComponent,
    canActivate: [AuthGuard]
  }
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CarsRoutingModule { }
