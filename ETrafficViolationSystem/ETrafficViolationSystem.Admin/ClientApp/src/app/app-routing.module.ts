import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {AuthGuard} from "./guards/auth.guard";
import {NotfoundComponent} from "./components/notfound/notfound.component";
import {DashboardComponent} from "./modules/dashboard/components/dashboard/dashboard.component";

const routes: Routes = [
  {
    path: 'account',
    loadChildren: () => import('./modules/account/account.module').then(module => module.AccountModule)
  },
  {
    path: 'dashboard',
    canActivate: [AuthGuard],
    loadChildren: () => import('./modules/dashboard/dashboard.module').then(module => module.DashboardModule)
  },
  {
    path: 'infractions',
    loadChildren: () => import('./modules/infractions/infractions.module').then(module => module.InfractionsModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'cars',
    loadChildren: () => import('./modules/cars/cars.module').then(module => module.CarsModule),
    canActivate: [AuthGuard]
  },
  {
    path: '404',
    component: NotfoundComponent,
    canActivate: [AuthGuard]
  },
  {
    path: '',
    component: DashboardComponent,
    canActivate: [AuthGuard]
  },
  {
    path: '**',
    redirectTo: '/404'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
