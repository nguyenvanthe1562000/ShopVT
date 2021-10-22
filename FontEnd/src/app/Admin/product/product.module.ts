import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductDataTableComponent } from './product-data-table/product-data-table.component';
import { ProductDetailComponent } from './product-detail/product-detail.component';



@NgModule({
  declarations: [
    ProductDataTableComponent,
    ProductDetailComponent
  ],
  imports: [
    CommonModule
  ]
})
export class ProductModule { }
