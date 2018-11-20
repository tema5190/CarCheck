import { Component, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { CarService } from 'src/app/shared/services/car.service';
import { UserCar, CarIdCardData } from 'src/app/models/dashboard/dashboard.models';

@Component({
    selector: 'app-dashboard',
    templateUrl: './dashboard.component.html',
    styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnDestroy {

    private carServiceSubscription: Subscription;
    public carItems = new Array<UserCar>();

    // Form field FIXME: make normal reactive form with models
    public carName: string;
    public firstName: string;
    public secondName: string;
    public thirdName: string;
    public carIdCardSeries: string;
    public carIdCardNumber: string;

    constructor(private carService: CarService) {
        this.carServiceSubscription = carService.getCarItemList().subscribe(cars => {
            this.carItems = cars;
        });
    }

    public ngOnDestroy(): void {
        if (this.carServiceSubscription && !this.carServiceSubscription.closed) {
            this.carServiceSubscription.unsubscribe();
        }
    }

    public addNewCar() {
        debugger;
        const newUserCar: UserCar = new UserCar();
        const carIdCardData: CarIdCardData = new CarIdCardData();
        carIdCardData.fullName = this.makeFullName();
        carIdCardData.certificateSeries = this.carIdCardSeries.trim();
        carIdCardData.certificateNumber = this.carIdCardNumber.trim();
        newUserCar.name = this.carName;
        newUserCar.carIdCardData = carIdCardData;

        const subscription = this.carService.addNewCar(newUserCar).subscribe(result => {
            if (result) {
                this.carItems.push(result);
            }

            subscription.unsubscribe();
        });
    }

    private makeFullName(): string {
        return `${this.firstName} ${this.secondName} ${this.thirdName}`.trim();
    }
}
