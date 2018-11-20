import { UserCar } from 'src/app/models/dashboard/dashboard.models';
import { ApiService } from './api.service';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable()
export class CarService {
    constructor(private apiService: ApiService) { }

    public addNewCar(newCar: UserCar): Observable<UserCar> {
        return this.apiService.post<UserCar>('car', newCar);
    }

    public getCarItemList(): Observable<UserCar[]> {
        return this.apiService.get<UserCar[]>('car');
    }
}
