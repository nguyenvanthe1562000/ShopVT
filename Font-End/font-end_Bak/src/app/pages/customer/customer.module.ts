import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { JwtHelperService } from '@auth0/angular-jwt';

import { RouterModule, Routes } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { HistoryOrderComponent } from './history-order/history-order.component';
import { ProfileComponent } from './profile/profile.component';
import { AddressComponent } from './address/address.component';
import { HistoryOrderDetailComponent } from './history-order-detail/history-order-detail.component';


export const authRoute: Routes = [
  {path:'',component: ProfileComponent},
  {path:'history-order',component: HistoryOrderComponent},
  {path:'address',component: AddressComponent},
  {path:'history-order/:id',component: HistoryOrderDetailComponent},
]
@NgModule({
  declarations: [
    HistoryOrderComponent,
    ProfileComponent,
    AddressComponent,
    HistoryOrderDetailComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forChild(authRoute)
  ]
})
export class CustomerModule { }
