import { Component, OnDestroy, Input } from '@angular/core';
import { UserCar } from 'src/app/models/dashboard/dashboard.models';
import { CarService } from 'src/app/shared/services/car.service';
import { Subscription } from 'rxjs/';


@Component({
    selector: 'app-car-list',
    templateUrl: './car-list.component.html',
})
export class CarListComponent {
    @Input() carItems: UserCar[];
}
