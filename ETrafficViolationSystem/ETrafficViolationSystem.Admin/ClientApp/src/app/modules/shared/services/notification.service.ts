import { Injectable } from '@angular/core';
import {ToastrService} from "ngx-toastr";

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  constructor(private toastr: ToastrService) { }

  success(message?: string, title?: string): void {
    this.toastr.success(message, title, {
      timeOut: 0,
    });
  }
}
