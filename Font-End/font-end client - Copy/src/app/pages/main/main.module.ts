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
import { LazyLoadImageModule} from 'ng-lazyload-image';
import { CoreModule } from '../../core/core.module';
import { TintucComponent } from './tintuc/tintuc.component';
import { TintucDetailComponent } from './tintuc-detail/tintuc-detail.component';
import { SearchComponent } from './search/search.component';
import { MenuComponent } from './menu/menu.component';



@NgModule({
  declarations: [HomeComponent, ProductListComponent,ProductDetailsComponent, AboutUsComponent, ContactUsComponent, CategoryListComponent, TintucComponent, TintucDetailComponent, SearchComponent, MenuComponent],
  imports: [
    NgbModule,
    CommonModule,LazyLoadImageModule,
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
        path:':url',
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
        path:'tin-tuc/:id',
        component: TintucComponent
      },
      {
        path:'tin-tuc-chi-tiet/:id',
        component: TintucDetailComponent
      },
      {
        path:'contact-us',
        component: ContactUsComponent
      },
      {
        path:'search/:id',
        component: SearchComponent
      },
    ]), 
  ]
})
export class MainModule { }
