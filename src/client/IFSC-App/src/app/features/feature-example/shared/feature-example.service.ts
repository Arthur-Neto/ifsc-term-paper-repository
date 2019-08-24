import {
    HttpClient,
    HttpHeaders,
} from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';

import { environment } from '../../../../environments/environment';
import {
    FeatureExampleAddCommand,
    FeatureExampleUpdateCommand,
    IFeatureExample,
} from './feature-example';

@Injectable({
    providedIn: 'root'
})
export class FeatureExampleService {

    private apiEndPoint: string;

    public constructor(
        private http: HttpClient,
    ) {
        this.apiEndPoint = `${ environment.apiUrl }/api/feature-example`;
    }

    public getAll(): Observable<IFeatureExample[]> {

        return this.http.get<IFeatureExample[]>(this.apiEndPoint).pipe();
    }

    public getByID(id: number): Observable<IFeatureExample[]> {

        return this.http.get<IFeatureExample[]>(`${ this.apiEndPoint }/${ id }`).pipe();
    }

    public add(command: FeatureExampleAddCommand): Observable<boolean> {

        return this.http.post<boolean>(this.apiEndPoint, command).pipe();
    }

    public update(command: FeatureExampleUpdateCommand): Observable<boolean> {

        return this.http.put<boolean>(this.apiEndPoint, command).pipe();
    }

    public remove(id: number): Observable<boolean> {

        return this.http.delete<boolean>(`${ this.apiEndPoint }/${ id }`).pipe();
    }
}
