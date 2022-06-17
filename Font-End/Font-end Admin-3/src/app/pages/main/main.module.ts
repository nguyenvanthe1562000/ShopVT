import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainComponent } from './main.component';
import { HttpClientModule } from '@angular/common/http';
import { DashboardComponent } from './dashboard/dashboard.component';
import { RouterModule, Routes } from '@angular/router';
import { SharedModule } from 'src/app/shared/shared.module';
import { ManageCategoriesComponent } from './manage-categories/manage-categories.component';
import { ManageProductsGroupComponent } from './manage-products-group/manage-products-group.component';
import { ManageProductsComponent } from './manage-products/manage-products.component';
import { ManageUsersComponent } from './manage-users/manage-users.component';
import { ManageOrdersComponent } from './manage-orders/manage-orders.component';
import { ManageProductBrandComponent } from './manage-product-brand/manage-product-brand.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ReactiveFormsModule } from '@angular/forms';
import {DialogModule} from 'primeng/dialog';
import {EditorModule} from 'primeng/editor';
import {TabViewModule} from 'primeng/tabview';

import {AutoComplete, AutoCompleteModule} from 'primeng/autocomplete';
import { FormsModule } from '@angular/forms';
import {ButtonModule} from 'primeng/button';
import {DropdownModule} from 'primeng/dropdown';
import {PanelModule} from 'primeng/panel';
import {TableModule} from 'primeng/table';
import {TreeSelectModule} from 'primeng/treeselect';
import { RoleGuard } from '../../core/auth.guard';
import { Role } from '../../shared/models/Role';
import { DateVNPipe } from '../../shared/pipes/DateVN.pipe';
import {ChartModule} from 'primeng/chart';
import {CalendarModule} from 'primeng/calendar';
import { PermisionComponent } from './permision/permision.component';
import { ManageReportComponent } from './manage-report/manage-report.component';
import { ManageAmountComponent } from './manage-amount/manage-amount.component';
import { AccDocComponent } from './acc-doc/acc-doc.component';
import { AccDocDetailComponent } from './acc-doc-detail/acc-doc-detail.component';
import { OpenInventoryComponent } from './open-inventory/open-inventory.component';
import { OpenInventorySystemComponent } from './open-inventory-system/open-inventory-system.component';
import { LoginEventComponent } from './login-event/login-event.component';

import { PostCategoryComponent } from './post-category/post-category.component';
import { PostComponent } from './post/post.component';
import { ProductCategoryComponent } from './product-category/product-category.component';
import { ProductComponent } from './product/product.component';
import { ManufacturerComponent } from './manufacturer/manufacturer.component';
import { SlideComponent } from './slide/slide.component';
import { EmployeeComponent } from './employee/employee.component';
import { CustomerComponent } from './customer/customer.component';
import { AppUserComponent } from './app-user/app-user.component';
// import { OrderComponent } from './order/order.component';
import { AccDocProductComponent } from './acc-doc-product/acc-doc-product.component';
import { OrderComponent } from './order/order.component';
import { EventlogComponent } from './eventlog/eventlog.component';
import { LogerrorComponent } from './logerror/logerror.component';
import { OpeninventoryComponent } from './openinventory/openinventory.component';

export const mainRoute: Routes = [
  {
    path: '',
    component: MainComponent,
    children: [
      {
        path: '',
        redirectTo:'dashboard',
        pathMatch: 'full'
      },
      {
        path: 'dashboard',
        component: DashboardComponent,
      },
     
      //post category
      {
        path: 'post-category',
        component: PostCategoryComponent,
      },
      //post
      {
        path: 'post',
        component: PostComponent,
      },
       //product-category
       {
        path: 'product-category',
        component: ProductCategoryComponent,
      },
      //manufacturer
      {
        path: 'manufacturer',
        component: ManufacturerComponent,
      },
      {
        path: 'product',
        component: ProductComponent,
      },
      {
        path: 'slide',
        component: SlideComponent,
      },
      {
        path: 'app-user',
        component: AppUserComponent,
      },
      {
        path: 'acc-doc',
        component: AccDocProductComponent,
      },
      {
        path: 'order',
        component: OrderComponent,
      },
      {
        path: 'history',
        component: EventlogComponent,
      },
      {
        path: 'log',
        component: LogerrorComponent,
      },
      {
        path: 'login-event',
        component: LoginEventComponent,
      },
    ]
  }
]
@NgModule({
  imports: [
    CommonModule,CalendarModule,
    SharedModule,
    HttpClientModule,
    ReactiveFormsModule,
    RouterModule.forChild(mainRoute),
    NgbModule,
    FormsModule,
    DialogModule,
    EditorModule,
    ButtonModule,
    DropdownModule,
    PanelModule,
    TableModule,
    ChartModule,
    TreeSelectModule,
    AutoCompleteModule,
    TabViewModule
  ],
  bootstrap:  [ MainComponent ],
  declarations: [MainComponent,    
    DashboardComponent, ManageCategoriesComponent, ManageProductsGroupComponent, ManageProductsComponent, ManageUsersComponent, ManageOrdersComponent, ManageProductBrandComponent, DateVNPipe, PermisionComponent,  ManageReportComponent, ManageAmountComponent, AccDocComponent, AccDocDetailComponent, OpenInventoryComponent, OpenInventorySystemComponent, LoginEventComponent, PostCategoryComponent, PostComponent, ProductCategoryComponent, ProductComponent, ManufacturerComponent, SlideComponent, EmployeeComponent, CustomerComponent, AppUserComponent, AccDocProductComponent,OrderComponent, EventlogComponent, LogerrorComponent, OpeninventoryComponent]
})
export class MainModule { }
