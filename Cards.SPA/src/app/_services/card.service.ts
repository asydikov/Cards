import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Card } from '../_models/card';
import { BaseService } from './base.service';
import { environment } from 'src/environments/environment';
import { UrlEnum } from '../_models/enums/url-enums';
import { DictionaryOkResponse } from '../_models/response-models/dictionary-ok-response';

@Injectable({
  providedIn: 'root'
})
export class CardService extends BaseService<Card> {

  constructor(http: HttpClient) {
    super(http, UrlEnum.Card);
  }

  /**
   * Retrieves all dictionaries from a server
   */
  getDependencies(): Observable<DictionaryOkResponse> {
    return this.http.get<DictionaryOkResponse>(`${environment.apiUrl}${this.baseUrl}dependencies`);
  }

}
