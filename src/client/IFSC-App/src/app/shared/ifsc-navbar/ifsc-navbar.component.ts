import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
    selector: 'ifsc-navbar',
    templateUrl: './ifsc-navbar.component.html',
    styleUrls: ['./ifsc-navbar.component.scss']
})
export class IfscNavbarComponent {

    constructor(private router: Router) { }

    public onClick() {
        this.router.navigateByUrl('');
    }
}