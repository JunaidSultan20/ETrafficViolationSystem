export class PaginationModel {
  pageSize: number;
  currentPage: number;
  totalRecords: number;

  constructor(pageSize: number, currentPage: number, totalRecords: number) {
    this.pageSize = pageSize;
    this.currentPage = currentPage;
    this.totalRecords = totalRecords;
  }
}
