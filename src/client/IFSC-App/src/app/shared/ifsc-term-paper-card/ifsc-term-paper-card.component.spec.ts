import {
    async,
    ComponentFixture,
    TestBed,
} from '@angular/core/testing';

import { IfscTermPaperCardComponent } from './ifsc-term-paper-card.component';

describe('IfscTermPaperCardComponent', () => {
    let component: IfscTermPaperCardComponent;
    let fixture: ComponentFixture<IfscTermPaperCardComponent>;

    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [IfscTermPaperCardComponent]
        })
            .compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(IfscTermPaperCardComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
