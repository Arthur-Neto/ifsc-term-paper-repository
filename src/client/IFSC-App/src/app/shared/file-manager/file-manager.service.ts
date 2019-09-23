import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';

import { environment } from '../../../environments/environment';

@Injectable({
    providedIn: 'root'
})
export class FileManagerService {

    private apiEndPoint: string;

    public constructor(
        private http: HttpClient,
    ) {
        this.apiEndPoint = `${ environment.apiUrl }/api/file-manager`;
    }

    public upload(formData: any): Observable<any> {
        return this.http.post<any>(this.apiEndPoint, formData, { reportProgress: true });
    }
}
