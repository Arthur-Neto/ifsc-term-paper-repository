import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';

import { environment } from '../../../../environments/environment';

@Injectable({
    providedIn: 'root'
})
export class TermPaperService {

    private apiEndPoint: string;

    public constructor(
        private http: HttpClient,
    ) {
        this.apiEndPoint = `${ environment.apiUrl }/api/term-paper`;
    }

    public add(command: any): Observable<any> {
        return this.http.post<boolean>(this.apiEndPoint, command, { reportProgress: true }).pipe();
    }

    public getAll(): Observable<any> {
        return this.http.get<any>(this.apiEndPoint).pipe();
    }

    public search(query: string): Observable<any> {
        return this.http.get<any>(`${ this.apiEndPoint }/search?query=${ query }`).pipe();
    }
}
