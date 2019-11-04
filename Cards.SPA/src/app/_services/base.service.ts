import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Card } from '../_models/card';
import { environment } from 'src/environments/environment';
import { OkResponse } from '../_models/response-models/ok-response';

@Injectable({
    providedIn: 'root'
})
export class BaseService<TModel> {

    constructor(protected http: HttpClient, protected baseUrl: string) { }

    /**
     * Get all entities
     */
    getAll(): Observable<OkResponse<TModel>> {
        return this.http.get<OkResponse<TModel>>(`${environment.apiUrl}${this.baseUrl}`);
    }

    /**
     * Get entity by id
     * @param id entity id
     */
    get(id: string): Observable<OkResponse<TModel>> {
        return this.http.get<OkResponse<TModel>>(`${environment.apiUrl}${this.baseUrl}${id}`);
    }

    /**
     * Create entity
    * @param model entity
     */
    post(model: TModel): Observable<OkResponse<TModel>> {
        return this.http.post<OkResponse<TModel>>(`${environment.apiUrl}${this.baseUrl}`, model);
    }

    /**
     * Update entity
     * @param model 
     */
    put(model: TModel): Observable<OkResponse<TModel>> {
        return this.http.put<OkResponse<TModel>>(`${environment.apiUrl}${this.baseUrl}`, model);
    }

    /**
     * Delete entity by id
     * @param entity id
     */
    delete(id: string): Observable<OkResponse<TModel>> {
        return this.http.delete<OkResponse<TModel>>(`${environment.apiUrl}${this.baseUrl}${id}`);
    }
}
