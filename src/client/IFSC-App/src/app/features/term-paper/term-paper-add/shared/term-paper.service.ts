import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';

import { environment } from '../../../../../environments/environment';
import { TermPaperAddCommand } from './term-paper.models';

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

    public add(command: TermPaperAddCommand): Observable<boolean> {

        return this.http.post<boolean>(this.apiEndPoint, command).pipe();
    }
}
