export interface IInfractions {
  infractionId: number,
  description: string,
  penalty: number,
  points: number,
  isActive: boolean,
  createdBy: number,
  createdDate: Date,
  updatedBy?: number,
  updateDate?: Date
}
