import {Component, OnInit} from '@angular/core';
import {RaceService} from "../services/race.service";
import {RaceModel} from "../models/race.models";
import {MatTableModule} from "@angular/material/table";
import {MatButton, MatButtonModule} from "@angular/material/button";
import {Router, RouterLink} from "@angular/router";
import {MatDialog} from "@angular/material/dialog";
import {DeleteRaceDialog} from "../dialogs/delete-race/delete-race-dialog.component";

@Component({
  selector: 'app-races',
  standalone: true,
  imports: [MatTableModule, MatButtonModule, RouterLink],
  templateUrl: './races.component.html',
  styleUrl: './races.component.scss'
})
export class RacesComponent implements OnInit {

  races: RaceModel[] = [];
  tableColumns: string[] = ['id', 'name', 'distance', 'actions'];

  constructor(
    private _raceService: RaceService,
    private _dialog: MatDialog,
    private _router: Router
  ) {}

  ngOnInit(): void {
    this._raceService.getRaces()
      .subscribe(response => this.races = response.races);
  }

  delete(race: RaceModel) {
    const dialogRef = this._dialog.open(DeleteRaceDialog);

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this._raceService.deleteRace(race.id)
          .subscribe({
            next: () => window.location.reload(),
            error: () => alert(`Error while deleting a race ${race.id}`)
          });
      }
    });
  }

  apply(race: RaceModel) {

  }

  createRace() {
    this._router.navigate(['/races/create']);
  }
}
