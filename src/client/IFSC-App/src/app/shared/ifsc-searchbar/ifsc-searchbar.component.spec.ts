import {
    async,
    ComponentFixture,
    TestBed,
} from '@angular/core/testing';

import { IfscSearchbarComponent } from './ifsc-searchbar.component';

describe('IfscSearchbarComponent', () => {
    let component: IfscSearchbarComponent;
    let fixture: ComponentFixture<IfscSearchbarComponent>;

    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [IfscSearchbarComponent]
        })
            .compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(IfscSearchbarComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
