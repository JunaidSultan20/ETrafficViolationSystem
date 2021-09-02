import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {HTTP_INTERCEPTORS, HttpClientModule} from "@angular/common/http";
import {AccountModule} from "./modules/account/account.module";
import {SharedModule} from "./modules/shared/shared.module";
import {InfractionsModule} from "./modules/infractions/infractions.module";
import {DashboardModule} from "./modules/dashboard/dashboard.module";
import {JwtInterceptor} from "./interceptors/jwt.interceptor";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import {NgxPaginationModule} from "ngx-pagination";
import {LayoutModule} from "./modules/layout/layout.module";
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

@NgModule({
    declarations: [
        AppComponent
    ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    SharedModule,
    HttpClientModule,
    AccountModule,
    InfractionsModule,
    DashboardModule,
    NgxPaginationModule,
    LayoutModule,
    FontAwesomeModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
