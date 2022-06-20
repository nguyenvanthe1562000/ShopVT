import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CheckoutComponent } from './checkout/checkout.component';
import { RouterModule } from '@angular/router';
import { CartComponent } from './cart/cart.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';

  
@NgModule({
  declarations: [
    CheckoutComponent,
    CartComponent,
    LoginComponent,
    RegisterComponent
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
        path:'login',
        component: LoginComponent
      },
      {
        path:'register',
        component: RegisterComponent
      }
    ])
  ]
})
export class ShoppingModule { }
