import { AuthService } from './services/auth.service';
import { ApiService } from './services/api.service';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
    imports: [
        HttpClientModule,
    ],
    providers: [
        ApiService,
        AuthService,
    ]
})
export class SharedModule { }
