import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {environment} from "../../environments/environment";
import {Observable} from "rxjs";
import {RaceListModel, RaceModel} from "../models/race.models";

@Injectable({
  providedIn: 'root'
})
export class RaceService {

  private _commandServiceBaseUrl = `${environment.commandServiceBaseUrl}/races`;
  private _queryServiceBaseUrl = `${environment.queryServiceBaseUrl}/races`;

  constructor(
    private _httpClient: HttpClient
  ) {
  }

  public getRaces(): Observable<RaceListModel> {
    return this._httpClient.get<RaceListModel>(this._queryServiceBaseUrl);
  }

  public getRace(raceId: string): Observable<RaceModel> {
    return this._httpClient.get<RaceModel>(`${this._queryServiceBaseUrl}/${raceId}`);
  }

  public editRace(raceId: string, raceModel: RaceModel): Observable<any> {
    return this._httpClient.put(`${this._commandServiceBaseUrl}/${raceId}`, raceModel);
  }

  public deleteRace(raceId: string): Observable<any> {
    return this._httpClient.delete(`${this._commandServiceBaseUrl}/${raceId}`);
  }
}
