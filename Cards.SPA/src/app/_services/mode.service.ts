import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Mode } from '../_models/mode';
import { HttpClient } from '@angular/common/http';
import { UrlEnum } from '../_models/enums/url-enums';


@Injectable({
  providedIn: 'root'
})
export class ModeService extends BaseService<Mode> {

  constructor(http: HttpClient) {
    super(http, UrlEnum.Mode);
  }
}