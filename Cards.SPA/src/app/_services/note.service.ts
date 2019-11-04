import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Note } from '../_models/note';
import { HttpClient } from '@angular/common/http';
import { UrlEnum } from '../_models/enums/url-enums';

@Injectable({
  providedIn: 'root'
})
export class NoteService extends BaseService<Note> {

  constructor(http: HttpClient) {
    super(http, UrlEnum.Note);
  }
}