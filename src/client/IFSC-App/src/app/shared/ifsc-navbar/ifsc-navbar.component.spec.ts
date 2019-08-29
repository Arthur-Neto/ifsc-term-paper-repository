import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IfscNavbarComponent } from './ifsc-navbar.component';

describe('IfscNavbarComponent', () => {
    let component: IfscNavbarComponent;
    let fixture: ComponentFixture<IfscNavbarComponent>;

    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [IfscNavbarComponent]
        })
            .compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(IfscNavbarComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
