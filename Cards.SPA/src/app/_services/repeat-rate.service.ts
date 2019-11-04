import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { RepeatRate } from '../_models/repeat-rate';
import { HttpClient } from '@angular/common/http';
import { UrlEnum } from '../_models/enums/url-enums';


@Injectable({
  providedIn: 'root'
})
export class RepeatRateService extends BaseService<RepeatRate> {

  constructor(http: HttpClient) {
    super(http, UrlEnum.RepeatRate);
  }
}
