import {
    async,
    ComponentFixture,
    TestBed,
} from '@angular/core/testing';

import { TermPaperAddComponent } from './term-paper-add.component';

describe('TermPaperAddComponent', () => {
    let component: TermPaperAddComponent;
    let fixture: ComponentFixture<TermPaperAddComponent>;

    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [TermPaperAddComponent]
        })
            .compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(TermPaperAddComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
