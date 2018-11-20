import { CommonModule } from '@angular/common';
import { CarListComponent } from './car-list/car-list.component';
import { DashboardComponent } from './dashboard.component';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
    imports: [
        // FormsModule,
        CommonModule,
        FormsModule,
        SharedModule,
    ],
    declarations: [
        DashboardComponent,
        CarListComponent,
    ],
})
export class DashboardModule { }
