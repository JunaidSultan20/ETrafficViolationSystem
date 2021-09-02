import { Component } from '@angular/core';
import { HelperService } from "./modules/shared/services/helper.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'ClientApp';

  constructor(public helper: HelperService) {
  }
}
