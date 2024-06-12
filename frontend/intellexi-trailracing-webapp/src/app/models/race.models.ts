export interface RaceListModel {
  races: RaceModel[];
}

export interface RaceModel {
  id: string;
  name: string;
  distance: string;
}

export enum RaceDistance {
  FiveKilometers = 0,
  TenKilometers = 1,
  HalfMarathon = 2,
  Marathon = 3
}
