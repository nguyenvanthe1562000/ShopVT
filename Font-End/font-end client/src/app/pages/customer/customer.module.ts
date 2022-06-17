import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { HistoryOrderComponent } from './history-order/history-order.component';
import { ProfileComponent } from './profile/profile.component';



@NgModule({
  declarations: [
    LoginComponent,
    RegisterComponent,
    HistoryOrderComponent,
    ProfileComponent
  ],
  imports: [
    CommonModule
  ]
})
export class CustomerModule { }
