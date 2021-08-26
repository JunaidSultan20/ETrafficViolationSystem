export interface IBaseResponse<T> {
  statusCode: number;
  message: string;
  isSuccessful: boolean;
  result: T;
  totalRecords: number | null;
  errors: string[];
}

