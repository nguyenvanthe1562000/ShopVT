import { NgModule } from '@angular/core';
import { HomeComponent } from './home/home.component';
import { ProductListComponent } from './product-list/product-list.component';
import { AboutUsComponent } from './about-us/about-us.component';
import { ContactUsComponent } from './contact-us/contact-us.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { NgbModule, NgbPagination } from '@ng-bootstrap/ng-bootstrap';
import { CategoryListComponent } from './category-list/category-list.component';
import { FormsModule } from '@angular/forms';
import { CoreModule } from '../../core/core.module';
import { TintucComponent } from './tintuc/tintuc.component';
import { TintucDetailComponent } from './tintuc-detail/tintuc-detail.component';



@NgModule({
  declarations: [HomeComponent, ProductListComponent,ProductDetailsComponent, AboutUsComponent, ContactUsComponent, CategoryListComponent, TintucComponent, TintucDetailComponent],
  imports: [
    NgbModule,
    CommonModule,
    CoreModule,
    RouterModule.forChild([
      {
        path: '',
        component: HomeComponent
      },
      {
        path:'product-list/:id',
        component: ProductListComponent
      },
      {
        path:'product-details/:id',
        component: ProductDetailsComponent
      },
      {
        path:'category-list/:id',
        component: CategoryListComponent
      },
      {
        path:'about-us',
        component: AboutUsComponent
      },
      {
        path:'tin-tuc',
        component: TintucComponent
      },
      {
        path:'tin-tuc/:id',
        component: TintucDetailComponent
      },
      {
        path:'contact-us',
        component: ContactUsComponent
      },
    ]), 
  ]
})
export class MainModule { }
