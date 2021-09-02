import { ChangeDetectionStrategy, Component, EventEmitter, Input, OnInit, Output,
  ViewEncapsulation } from '@angular/core';
import {PaginationModel} from "../../models/paginationModel";

@Component({
  selector: 'app-pagination',
  templateUrl: './pagination.component.html',
  styleUrls: ['./pagination.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  encapsulation: ViewEncapsulation.None
})
export class PaginationComponent implements OnInit {
  @Input() paginationConfig: PaginationModel | undefined;
  @Output() pageChange: EventEmitter<number>;
  @Output() pageSize: EventEmitter<number>;
  //Pagination Control Variables
  autoHide: boolean = false;
  responsive: boolean = true;
  itemsPerPage: number = 10;

  constructor() {
    this.pageChange = new EventEmitter<number>();
    this.pageSize = new EventEmitter<number>();
  }

  ngOnInit(): void {
  }

  handlePageChange(value: number) {
    this.pageChange.emit(value)
  }

  onItemsChange(value: number) {
    this.pageSize.emit(value);
  }
}
