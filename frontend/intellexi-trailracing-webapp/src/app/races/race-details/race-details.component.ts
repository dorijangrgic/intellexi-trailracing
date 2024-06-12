import {Component} from '@angular/core';
import {RaceService} from "../../services/race.service";
import {ActivatedRoute, Router} from "@angular/router";
import {FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators} from "@angular/forms";
import {MatFormFieldModule} from "@angular/material/form-field";
import {MatInputModule} from "@angular/material/input";
import {MatButtonModule} from "@angular/material/button";
import {CommonModule} from "@angular/common";

@Component({
  selector: 'app-race-details',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    MatFormFieldModule,
    MatButtonModule,
    MatInputModule,
    CommonModule
  ],
  templateUrl: './race-details.component.html',
  styleUrl: './race-details.component.scss'
})
export class RaceDetailsComponent {

  raceId: string = '';
  raceForm: FormGroup;

  constructor(
    private _raceService: RaceService,
    private _route: ActivatedRoute,
    private _formBuilder: FormBuilder,
    private _router: Router
  ) {
    this._route.params.subscribe(params => {
      this.raceId = params['id'];
      this.getRaceDetails();
    });

    this.raceForm = this._formBuilder.group({
      id: new FormControl({value: '', disabled: true}, Validators.required),
      name: ['', Validators.required],
      distance: ['', Validators.required]
    });
  }

  getRaceDetails(): void {
    this._raceService.getRace(this.raceId)
      .subscribe(response => {
        this.raceForm.setValue(response);
      });
  }

  editRace(): void {
    this._raceService.editRace(this.raceId, this.raceForm.value)
      .subscribe({
        next: (response) => {
          this._router.navigate(['../'], { relativeTo: this._route });
        },
        error: () => {}
      });
  }
}
