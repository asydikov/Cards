import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { HttpClient } from '@angular/common/http';
import { UrlEnum } from '../_models/enums/url-enums';
import { User } from '../_models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService extends BaseService<User> {

  constructor(http: HttpClient) {
    super(http, UrlEnum.User);
  }

}