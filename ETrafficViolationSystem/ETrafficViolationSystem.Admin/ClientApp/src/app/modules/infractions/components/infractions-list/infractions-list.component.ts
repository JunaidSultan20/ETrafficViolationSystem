import { Component, OnInit } from '@angular/core';
import {IInfractions} from "../../interfaces/infractions";
import {PaginationModel} from "../../../shared/models/paginationModel";
import { faEdit } from '@fortawesome/free-regular-svg-icons';
import { faTimes } from "@fortawesome/free-solid-svg-icons";
import { faCheck } from "@fortawesome/free-solid-svg-icons";
import { faEllipsisV } from "@fortawesome/free-solid-svg-icons";
import {InfractionsService} from "../../services/infractions.service";
import {StatusCode} from "../../../shared/enums/statusCode";
import {NgxSpinnerService} from "ngx-spinner";

@Component({
  selector: 'app-infractions-list',
  templateUrl: './infractions-list.component.html',
  styleUrls: ['./infractions-list.component.scss']
})
export class InfractionsListComponent implements OnInit {
  infractionsList: IInfractions[] = [];
  //Pagination Variables
  pageSize: number = 10;
  currentPage: number = 1;
  totalRecords: number | undefined = 0;
  //Pagination Control Variables
  paginationConfig: PaginationModel;
  //Fontawesome Variables
  faEdit = faEdit;
  faTimes = faTimes;
  faCheck = faCheck;
  faEllipsisV = faEllipsisV;

  constructor(private infractionsService: InfractionsService, private spinnerService: NgxSpinnerService) {
    this.paginationConfig = new PaginationModel(10, 1, 0);
  }

  ngOnInit(): void {
    this.getInfractionsList();
  }

  getInfractionsList() {
    this.spinnerService.show();
    this.infractionsService.getInfractionsList(this.currentPage, this.pageSize).subscribe({
      next: response => {
        if (response.statusCode == StatusCode.Ok && response.isSuccessful) {
          this.infractionsList = response.result;
          this.totalRecords = response.totalRecords;
          this.spinnerService.hide();
        }
      }
    });
  }

  handlePageChange(value: number) {
    this.currentPage = value;
    this.getInfractionsList();
  }

  itemsPerPage(value: number) {
    this.pageSize = value;
    this.currentPage = 1;
    this.getInfractionsList();
  }

  deleteInfraction(infractionId: number) {
    console.log(infractionId);
  }
}
