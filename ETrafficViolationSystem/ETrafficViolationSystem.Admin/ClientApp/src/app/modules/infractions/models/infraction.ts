export class Infraction {
  description: string | undefined;
  penalty: number | undefined;
  points: number | undefined;
}

export class InfractionsInsertRequest {
  infraction : Infraction | undefined;
}
