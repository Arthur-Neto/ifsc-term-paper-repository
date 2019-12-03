import {
    async,
    ComponentFixture,
    TestBed,
} from '@angular/core/testing';

import { TermPaperListComponent } from './term-paper-list.component';

describe('TermPaperListComponent', () => {
    let component: TermPaperListComponent;
    let fixture: ComponentFixture<TermPaperListComponent>;

    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [TermPaperListComponent]
        })
            .compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(TermPaperListComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
