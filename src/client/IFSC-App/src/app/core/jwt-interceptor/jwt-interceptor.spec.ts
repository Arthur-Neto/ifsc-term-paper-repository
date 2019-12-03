import {
    async,
    ComponentFixture,
    TestBed,
} from '@angular/core/testing';

import { JwtInterceptor } from './jwt-interceptor';

describe('JwtInterceptor', () => {
    let component: JwtInterceptor;
    let fixture: ComponentFixture<JwtInterceptor>;

    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [JwtInterceptor]
        })
            .compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(JwtInterceptor);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
