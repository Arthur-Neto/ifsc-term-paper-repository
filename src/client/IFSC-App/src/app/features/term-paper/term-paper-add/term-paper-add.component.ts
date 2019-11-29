import {
    COMMA,
    ENTER,
} from '@angular/cdk/keycodes';
import { HttpEventType } from '@angular/common/http';
import {
    Component,
    ElementRef,
    OnInit,
    ViewChild,
} from '@angular/core';
import {
    FormBuilder,
    FormGroup,
    Validators,
} from '@angular/forms';
import {
    MatAutocomplete,
    MatAutocompleteSelectedEvent,
} from '@angular/material/autocomplete';
import { MatChipInputEvent } from '@angular/material/chips';
import { Router } from '@angular/router';

import { Observable } from 'rxjs';
import {
    map,
    take,
} from 'rxjs/operators';

import resources from '../../../../assets/resources/resources-ptBR.json';
import { FileManagerService } from '../../../shared/file-manager/file-manager.service.js';
import { TermPaperService } from '../shared/term-paper.service.js';

@Component({
    selector: 'term-paper-add',
    templateUrl: './term-paper-add.component.html',
    styleUrls: ['./term-paper-add.component.scss']
})
export class TermPaperAddComponent implements OnInit {

    public readonly MIN_DATE = new Date(2010, 1, 1);
    public readonly MAX_DATE = new Date();
    public readonly resources = resources;
    public readonly separatorKeysCodes: number[] = [ENTER, COMMA];

    public termPaper: FormGroup;
    public hasCoAdvisor = false;
    public hasTwoStudents = false;
    public file: any;
    public progress: any;
    public fileName: string;
    public fileUploadedShowError = false;
    public keywords: string[] = [];
    public allKeywords: string[] = ['keyword1', 'keyword2', 'keyword3'];
    public filteredKeywords: Observable<string[]>;

    get f() { return this.termPaper.controls; }

    @ViewChild('keywordInput', { static: false }) keywordInput: ElementRef<HTMLInputElement>;
    @ViewChild('auto', { static: false }) matAutocomplete: MatAutocomplete;

    constructor(
        private termPaperService: TermPaperService,
        private fileManagerService: FileManagerService,
        private router: Router,
        private fb: FormBuilder
    ) { }

    ngOnInit() {
        this.termPaper = this.fb.group({
            title: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(100)]],
            area: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
            course: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(100)]],
            dateBegin: ['', [Validators.required]],
            dateEnd: ['', [Validators.required]],
            advisor: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
            coAdvisor: ['', [Validators.minLength(4), Validators.maxLength(50)]],
            student1: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
            student2: ['', [Validators.minLength(4), Validators.maxLength(50)]],
            keywords: [''],
        });

        this.filteredKeywords =
            this.f.keywords.valueChanges
                .pipe(map((keyword: string | null) => this.filterKeywords(keyword)));
    }

    public fileChange(file: any) {
        this.file = file.target.files[0] ? file.target.files[0] : this.file;
        this.fileName = this.file.name;
        this.fileUploadedShowError = false;
    }

    public keywordAdd(event: MatChipInputEvent): void {
        if (!this.matAutocomplete.isOpen) {
            const input = event.input;
            const value = event.value;

            if ((value || '').trim()) {
                this.keywords.push(value.trim());
            }

            if (input) {
                input.value = '';
            }

            this.f.keywords.setValue(this.keywords);
        }
    }

    public keywordRemove(keyword: string): void {
        const index = this.keywords.indexOf(keyword);

        if (index >= 0) {
            this.keywords.splice(index, 1);
        }
    }

    public keywordSelected(event: MatAutocompleteSelectedEvent): void {
        if (!event.option) { return; }
        const value = event.option.value;

        if ((value || '').trim()) {
            this.keywords.push(value.trim());
            this.f.keywords.setValue('');
        }
    }

    public onAddCoAdvisor() {
        this.f.coAdvisor.enable();
        this.hasCoAdvisor = true;
    }

    public onRemoveCoAdvisor() {
        this.hasCoAdvisor = false;
        this.f.coAdvisor.disable();
    }

    public onAddStudent() {
        this.f.student2.enable();
        this.hasTwoStudents = true;
    }

    public onRemoveStudent() {
        this.hasTwoStudents = false;
        this.f.student2.disable();
    }

    public onSubmit(termPaper: FormGroup) {
        if (!this.file || !(this.file.type === 'application/pdf') || this.file.length === 0) {
            this.fileUploadedShowError = true;
            return;
        } else {
            this.fileUploadedShowError = false;
        }

        const fileToUpload = this.file as File;
        const formData = new FormData();
        formData.append('title', termPaper.value.title);
        formData.append('area', termPaper.value.area);
        formData.append('course', termPaper.value.course);
        formData.append('dateBegin', new Date(termPaper.value.dateBegin).toUTCString());
        formData.append('dateEnd', new Date(termPaper.value.dateEnd).toUTCString());
        formData.append('advisor', termPaper.value.advisor);
        formData.append('coAdvisor', termPaper.value.coAdvisor);
        formData.append('student1', termPaper.value.student1);
        formData.append('student2', termPaper.value.student2);
        formData.append('keywords', termPaper.value.keywords);
        formData.append('file', fileToUpload, fileToUpload.name);
        formData.append('fileName', fileToUpload.name);

        this.termPaperService
            .add(formData)
            .pipe(take(1))
            .subscribe((event) => {
                if (event.type === HttpEventType.UploadProgress) {
                    this.progress = Math.round(100 * event.loaded / event.total);
                }

                this.router.navigateByUrl('\home');
            });
    }

    public onReset() {
        this.router.navigateByUrl('');
    }

    private filterKeywords(value: string): string[] {
        const matches = value ? this.allKeywords.filter((s) => new RegExp(`^${ value }`, 'gi').test(s)) : this.allKeywords;

        return matches.filter((x) => !this.keywords.find((y) => y === x));
    }
}
