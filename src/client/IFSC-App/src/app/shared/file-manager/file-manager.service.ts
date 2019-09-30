import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import {
    Observable,
    of,
} from 'rxjs';

import { environment } from '../../../environments/environment';

@Injectable({
    providedIn: 'root'
})
export class FileManagerService {

    private apiEndPoint: string;

    private readonly termPapers: any[] = [
        {
            title: 'Repositório de TCCs',
            subTitle: 'Ciência da Computação',
            studentA: 'Arthur Santos Neto',
            studentB: 'Johnson Sadao',
            advisor: 'Alexandre Perin',
            coAdvisor: '-',
        },
        {
            title: 'Repositório de TCCs',
            subTitle: 'Ciência da Computação',
            studentA: 'Arthur Santos Neto',
            studentB: 'Johnson Sadao',
            advisor: 'Alexandre Perin',
            coAdvisor: '-',
        },
        {
            title: 'Repositório de TCCs',
            subTitle: 'Ciência da Computação',
            studentA: 'Arthur Santos Neto',
            studentB: 'Johnson Sadao',
            advisor: 'Alexandre Perin',
            coAdvisor: '-',
        },
        {
            title: 'Repositório de TCCs',
            subTitle: 'Ciência da Computação',
            studentA: 'Arthur Santos Neto',
            studentB: 'Johnson Sadao',
            advisor: 'Alexandre Perin',
            coAdvisor: '-',
        },
        {
            title: 'Repositório de TCCs',
            subTitle: 'Ciência da Computação',
            studentA: 'Arthur Santos Neto',
            studentB: 'Johnson Sadao',
            advisor: 'Alexandre Perin',
            coAdvisor: '-',
        },
        {
            title: 'Repositório de TCCs',
            subTitle: 'Ciência da Computação',
            studentA: 'Arthur Santos Neto',
            studentB: 'Johnson Sadao',
            advisor: 'Alexandre Perin',
            coAdvisor: '-',
        },
        {
            title: 'Repositório de TCCs',
            subTitle: 'Ciência da Computação',
            studentA: 'Arthur Santos Neto',
            studentB: 'Johnson Sadao',
            advisor: 'Alexandre Perin',
            coAdvisor: '-',
        },
        {
            title: 'Repositório de TCCs',
            subTitle: 'Ciência da Computação',
            studentA: 'Arthur Santos Neto',
            studentB: 'Johnson Sadao',
            advisor: 'Alexandre Perin',
            coAdvisor: '-',
        },
        {
            title: 'Repositório de TCCs',
            subTitle: 'Ciência da Computação',
            studentA: 'Arthur Santos Neto',
            studentB: 'Johnson Sadao',
            advisor: 'Alexandre Perin',
            coAdvisor: '-',
        },
        {
            title: 'Repositório de TCCs',
            subTitle: 'Ciência da Computação',
            studentA: 'Arthur Santos Neto',
            studentB: 'Johnson Sadao',
            advisor: 'Alexandre Perin',
            coAdvisor: '-',
        },
        {
            title: 'Repositório de TCCs',
            subTitle: 'Ciência da Computação',
            studentA: 'Arthur Santos Neto',
            studentB: 'Johnson Sadao',
            advisor: 'Alexandre Perin',
            coAdvisor: '-',
        },
        {
            title: 'Repositório de TCCs',
            subTitle: 'Ciência da Computação',
            studentA: 'Arthur Santos Neto',
            studentB: 'Johnson Sadao',
            advisor: 'Alexandre Perin',
            coAdvisor: '-',
        },
        {
            title: 'Repositório de TCCs',
            subTitle: 'Ciência da Computação',
            studentA: 'Arthur Santos Neto',
            studentB: 'Johnson Sadao',
            advisor: 'Alexandre Perin',
            coAdvisor: '-',
        },
        {
            title: 'Repositório de TCCs',
            subTitle: 'Ciência da Computação',
            studentA: 'Arthur Santos Neto',
            studentB: 'Johnson Sadao',
            advisor: 'Alexandre Perin',
            coAdvisor: '-',
        },
        {
            title: 'Repositório de TCCs',
            subTitle: 'Ciência da Computação',
            studentA: 'Arthur Santos Neto',
            studentB: 'Johnson Sadao',
            advisor: 'Alexandre Perin',
            coAdvisor: '-',
        },
        {
            title: 'Repositório de TCCs',
            subTitle: 'Ciência da Computação',
            studentA: 'Arthur Santos Neto',
            studentB: 'Johnson Sadao',
            advisor: 'Alexandre Perin',
            coAdvisor: '-',
        },
        {
            title: 'Repositório de TCCs',
            subTitle: 'Ciência da Computação',
            studentA: 'Arthur Santos Neto',
            studentB: 'Johnson Sadao',
            advisor: 'Alexandre Perin',
            coAdvisor: '-',
        },
        {
            title: 'Repositório de TCCs',
            subTitle: 'Ciência da Computação',
            studentA: 'Arthur Santos Neto',
            studentB: 'Johnson Sadao',
            advisor: 'Alexandre Perin',
            coAdvisor: '-',
        },
        {
            title: 'Repositório de TCCs',
            subTitle: 'Ciência da Computação',
            studentA: 'Arthur Santos Neto',
            studentB: 'Johnson Sadao',
            advisor: 'Alexandre Perin',
            coAdvisor: '-',
        },
        {
            title: 'Repositório de TCCs',
            subTitle: 'Ciência da Computação',
            studentA: 'Arthur Santos Neto',
            studentB: 'Johnson Sadao',
            advisor: 'Alexandre Perin',
            coAdvisor: '-',
        },
        {
            title: 'Repositório de TCCs',
            subTitle: 'Ciência da Computação',
            studentA: 'Arthur Santos Neto',
            studentB: 'Johnson Sadao',
            advisor: 'Alexandre Perin',
            coAdvisor: '-',
        },
        {
            title: 'Repositório de TCCs',
            subTitle: 'Ciência da Computação',
            studentA: 'Arthur Santos Neto',
            studentB: 'Johnson Sadao',
            advisor: 'Alexandre Perin',
            coAdvisor: '-',
        },
        {
            title: 'Repositório de TCCs',
            subTitle: 'Ciência da Computação',
            studentA: 'Arthur Santos Neto',
            studentB: 'Johnson Sadao',
            advisor: 'Alexandre Perin',
            coAdvisor: '-',
        },
        {
            title: 'Repositório de TCCs',
            subTitle: 'Ciência da Computação',
            studentA: 'Arthur Santos Neto',
            studentB: 'Johnson Sadao',
            advisor: 'Alexandre Perin',
            coAdvisor: '-',
        },
        {
            title: 'Repositório de TCCs',
            subTitle: 'Ciência da Computação',
            studentA: 'Arthur Santos Neto',
            studentB: 'Johnson Sadao',
            advisor: 'Alexandre Perin',
            coAdvisor: '-',
        },
        {
            title: 'Repositório de TCCs',
            subTitle: 'Ciência da Computação',
            studentA: 'Arthur Santos Neto',
            studentB: 'Johnson Sadao',
            advisor: 'Alexandre Perin',
            coAdvisor: '-',
        },
        {
            title: 'Repositório de TCCs',
            subTitle: 'Ciência da Computação',
            studentA: 'Arthur Santos Neto',
            studentB: 'Johnson Sadao',
            advisor: 'Alexandre Perin',
            coAdvisor: '-',
        },
        {
            title: 'Repositório de TCCs',
            subTitle: 'Ciência da Computação',
            studentA: 'Arthur Santos Neto',
            studentB: 'Johnson Sadao',
            advisor: 'Alexandre Perin',
            coAdvisor: '-',
        }
    ];

    public constructor(
        private http: HttpClient,
    ) {
        this.apiEndPoint = `${ environment.apiUrl }/api/file-manager`;
    }

    public upload(formData: any): Observable<any> {
        return this.http.post<any>(this.apiEndPoint, formData, { reportProgress: true });
    }

    public download(fileName: any): Observable<any> {
        return this.http.get<any>(`${ this.apiEndPoint }/download?filename=${ fileName }`, { reportProgress: true });
    }

    public getAll(): Observable<any> {
        // return this.http.get<any>(`${ this.apiEndPoint }/get-all`, { reportProgress: true }).pipe();

        return of(this.termPapers);
    }

    public getByQuery(query: string): Observable<any> {
        return this.http.get<any>(`${ this.apiEndPoint }/search?query=${ query }`, { reportProgress: true }).pipe();
    }
}
