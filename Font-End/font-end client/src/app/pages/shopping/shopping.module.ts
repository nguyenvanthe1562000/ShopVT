import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CheckoutComponent } from './checkout/checkout.component';
import { RouterModule } from '@angular/router';
import { CartComponent } from './cart/cart.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LoginComponent } from './login/login.component';



@NgModule({
  declarations: [
    CheckoutComponent,
    CartComponent,
    LoginComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule.forChild([
      {
        path: 'cart',
        component: CartComponent
      },
      {
        path:'checkout',
        component: CheckoutComponent
      },
      {
        path:'register',
        component: LoginComponent
      }
    ])
  ]
})
export class ShoppingModule { }
