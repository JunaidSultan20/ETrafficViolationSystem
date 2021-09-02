import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { MenuComponent } from './components/menu/menu.component';
import {RouterModule} from "@angular/router";



@NgModule({
    declarations: [
        HeaderComponent,
        FooterComponent,
        MenuComponent
    ],
  exports: [
    HeaderComponent,
    MenuComponent,
    FooterComponent
  ],
    imports: [
        CommonModule,
        RouterModule
    ]
})
export class LayoutModule { }
