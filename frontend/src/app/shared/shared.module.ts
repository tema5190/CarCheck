import { FormsModule } from '@angular/forms';
import { CarService } from 'src/app/shared/services/car.service';
import { AuthService } from './services/auth.service';
import { ApiService } from './services/api.service';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
    imports: [
        HttpClientModule,
        FormsModule,
    ],
    providers: [
        ApiService,
        AuthService,
        CarService,
    ]
})
export class SharedModule { }
