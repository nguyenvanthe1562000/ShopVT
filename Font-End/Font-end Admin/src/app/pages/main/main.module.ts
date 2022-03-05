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
import { FormsModule } from '@angular/forms';
import {ButtonModule} from 'primeng/button';
import {DropdownModule} from 'primeng/dropdown';
import {PanelModule} from 'primeng/panel';
import {TableModule} from 'primeng/table';
import { RoleGuard } from '../../core/auth.guard';
import { Role } from '../../shared/models/Role';
import { DateVNPipe } from '../../shared/pipes/DateVN.pipe';
import {ChartModule} from 'primeng/chart';
import { TintucComponent } from './tintuc/tintuc.component';
import {CalendarModule} from 'primeng/calendar';
import { PermisionComponent } from './permision/permision.component';
import { PermisionDetailComponent } from './permision-detail/permision-detail.component';
import { ProductInfomationComponent } from './product-infomation/product-infomation.component';
import { ManageReportComponent } from './manage-report/manage-report.component';
import { ManageAmountComponent } from './manage-amount/manage-amount.component';
import { AccDocComponent } from './acc-doc/acc-doc.component';
import { AccDocDetailComponent } from './acc-doc-detail/acc-doc-detail.component';
import { OpenInventoryComponent } from './open-inventory/open-inventory.component';
import { OpenInventorySystemComponent } from './open-inventory-system/open-inventory-system.component';
import { LoginEventComponent } from './login-event/login-event.component';
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
      }, {
        path: 'tin-tuc',
        component: TintucComponent,
      },
      
      {
        path: 'manage-categories',
        component: ManageCategoriesComponent,
      },
      {
        path: 'manage-product-brand',
        component: ManageProductBrandComponent,
      },
      {
        path: 'manage-products',
        component: ManageProductsComponent
      },
      {
        path: 'manage-users',
        component: ManageUsersComponent
       
      },
      {
        path: 'manage-orders',
        component: ManageOrdersComponent,
      },
      {
        path: 'manage-permision',
        component: PermisionComponent,
      },
      {
        path: 'manage-permision-detail',
        component: PermisionDetailComponent,
      },
      {
        path: 'manage-product-detail',
        component: ProductInfomationComponent,
      },
      {
        path: 'manage-best-selling',
        component: ManageReportComponent,
      },
      {
        path: 'manage-amount',
        component: ManageAmountComponent,
      },
      {
        path: 'manage-permision',
        component: PermisionComponent,
      },
      {
        path: 'manage-acc-doc',
        component: AccDocComponent,
      },
      {
        path: 'manage-open-inventory',
        component: OpenInventoryComponent,
      },
      {
        path: 'manage-acc-doc-detail/:id',
        component: AccDocDetailComponent,
      },
      {
        path: 'manage-acc-doc-detail',
        component: AccDocDetailComponent,
      },
      {
        path: 'open-inventory-system',
        component: OpenInventorySystemComponent,
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
    ChartModule
  ],
  declarations: [MainComponent,    TintucComponent,
    DashboardComponent, ManageCategoriesComponent, ManageProductsGroupComponent, ManageProductsComponent, ManageUsersComponent, ManageOrdersComponent, ManageProductBrandComponent, DateVNPipe, PermisionComponent, PermisionDetailComponent, ProductInfomationComponent, ManageReportComponent, ManageAmountComponent, AccDocComponent, AccDocDetailComponent, OpenInventoryComponent, OpenInventorySystemComponent, LoginEventComponent]
})
export class MainModule { }
