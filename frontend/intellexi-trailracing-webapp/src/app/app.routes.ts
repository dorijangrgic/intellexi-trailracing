import {Routes} from '@angular/router';
import {RacesComponent} from "./races/races.component";
import {ApplicationsComponent} from "./applications/applications.component";
import {RaceDetailsComponent} from "./races/race-details/race-details.component";
import {RaceCreateComponent} from "./races/race-create/race-create.component";

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'races',
    pathMatch: 'full'
  },
  {
    path: 'races',
    component: RacesComponent,
  },
  {
    path: 'races/:id',
    component: RaceDetailsComponent
  },
  {
    path: 'races/createRace',
    component: RaceCreateComponent
  },
  {
    path: 'applications',
    component: ApplicationsComponent,
  },
  {
    path: 'applications/:id',
    component: ApplicationsComponent
  }
];
