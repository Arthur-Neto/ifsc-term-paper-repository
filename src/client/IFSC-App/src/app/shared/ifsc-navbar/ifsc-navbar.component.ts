import {
    Component,
    EventEmitter,
    Input,
    Output,
} from '@angular/core';
import { Router } from '@angular/router';

@Component({
    selector: 'ifsc-navbar',
    templateUrl: './ifsc-navbar.component.html',
    styleUrls: ['./ifsc-navbar.component.scss']
})
export class IfscNavbarComponent {
    @Input() isLogged: boolean;

    @Output() logout = new EventEmitter<any>();

    constructor(private router: Router) { }

    public onLogoClick() {
        this.router.navigateByUrl('');
    }

    public onLogin() {
        this.router.navigateByUrl('login');
    }

    public onLogout() {
        this.logout.emit();
    }
}
