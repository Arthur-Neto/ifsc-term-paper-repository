import {
    async,
    ComponentFixture,
    TestBed,
} from '@angular/core/testing';

import { IfscSpinnerComponent } from './ifsc-spinner.component';

describe('IfscSpinnerComponent', () => {
    let component: IfscSpinnerComponent;
    let fixture: ComponentFixture<IfscSpinnerComponent>;

    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [IfscSpinnerComponent]
        })
            .compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(IfscSpinnerComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
