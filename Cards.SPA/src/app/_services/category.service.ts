import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Category } from '../_models/category';
import { HttpClient } from '@angular/common/http';
import { UrlEnum } from '../_models/enums/url-enums';


@Injectable({
  providedIn: 'root'
})
export class CategoryService extends BaseService<Category> {

  constructor(http: HttpClient) {
    super(http, UrlEnum.Category);
  }
}
