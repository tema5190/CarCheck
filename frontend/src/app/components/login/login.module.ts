import { NgModule } from '@angular/core';
import { LoginComponent } from './login.component';
import { FormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
    imports: [
        FormsModule,
        SharedModule
    ],
    declarations: [
        LoginComponent
    ],
})
export class LoginModule { }
