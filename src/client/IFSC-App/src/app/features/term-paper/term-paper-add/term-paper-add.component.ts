import {
    COMMA,
    ENTER,
} from '@angular/cdk/keycodes';
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

import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import resources from '../../../../assets/resources/resources-ptBR.json';

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

    public formGroup: FormGroup;
    public filteredKeywords: Observable<string[]>;
    public keywords: string[] = ['CallFromBackend'];
    public allKeywords: string[] = ['Keyword1', 'Keyword2', 'Keyword3'];

    get f() { return this.formGroup.controls; }

    @ViewChild('keywordInput', { static: false }) keywordInput: ElementRef<HTMLInputElement>;
    @ViewChild('auto', { static: false }) matAutocomplete: MatAutocomplete;

    constructor(
        private fb: FormBuilder
    ) { }

    ngOnInit() {
        this.formGroup = this.fb.group({
            title: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(100)]],
            area: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
            course: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(100)]],
            dateBegin: ['', [Validators.required]],
            dateEnd: ['', [Validators.required]],
            advisor: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
            student: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
            keywords: [''],
        });

        this.filteredKeywords =
            this.f.keywords.valueChanges
                .pipe(map((keyword: string | null) => keyword ? this.filterKeywords(keyword) : this.allKeywords.slice()));
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

            this.f.keywords.setValue(null);
        }
    }

    public keywordRemove(keyword: string): void {
        const index = this.keywords.indexOf(keyword);

        if (index >= 0) {
            this.keywords.splice(index, 1);
        }
    }

    public keywordSelected(event: MatAutocompleteSelectedEvent): void {
        this.keywords.push(event.option.viewValue);
        this.keywordInput.nativeElement.value = '';
        this.f.keywords.setValue(null);
    }

    private filterKeywords(value: string): string[] {
        const filterValue = value.toLowerCase();

        return this.allKeywords.filter((keyword) => keyword.toLowerCase().indexOf(filterValue) === 0);
    }
}
