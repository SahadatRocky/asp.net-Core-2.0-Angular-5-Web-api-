import { Component } from '@angular/core';
import { Greeter } from "../../services/Greeter";


@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    providers:[Greeter]
    
})
export class HomeComponent {

    private _greeter: Greeter;
    public message: string;
    constructor(greeter: Greeter) {
        this._greeter = greeter;
        this.message = this._greeter.greeter("Rocky");
    }

}
