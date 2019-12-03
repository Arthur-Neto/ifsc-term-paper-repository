import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import {
    BehaviorSubject,
    Observable,
} from 'rxjs';
import { map } from 'rxjs/operators';

import { environment } from '../../../../environments/environment';

@Injectable({
    providedIn: 'root'
})
export class LoginService {
    public currentUser: Observable<any>;

    private currentUserSubject: BehaviorSubject<any>;
    private apiEndPoint: string;

    public constructor(
        private http: HttpClient,
    ) {
        this.apiEndPoint = `${ environment.apiUrl }/api/public`;

        this.currentUserSubject = new BehaviorSubject<any>(JSON.parse(localStorage.getItem('currentUser')));
        this.currentUser = this.currentUserSubject.asObservable();
    }

    public get currentUserValue(): any {
        return this.currentUserSubject.value;
    }

    public login(command: any): Observable<any> {
        return this.http.post<any>(this.apiEndPoint, command).pipe(
            map((advisor) => {
                if (advisor && advisor.token) {
                    localStorage.setItem('currentUser', JSON.stringify(advisor));
                    this.currentUserSubject.next(advisor);
                }

                return advisor;
            })
        );
    }
}
