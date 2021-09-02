import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from "./guards/auth.guard";

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
    canActivate: [AuthGuard],
    loadChildren: () => import('./modules/infractions/infractions.module').then(module => module.InfractionsModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
