import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainComponent } from './main.component';
import { HttpClientModule } from '@angular/common/http';
import { DashboardComponent } from './dashboard/dashboard.component';
import { RouterModule, Routes } from '@angular/router';
import { SharedModule } from 'src/app/shared/shared.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ReactiveFormsModule } from '@angular/forms';
import {DialogModule} from 'primeng/dialog';
import {EditorModule} from 'primeng/editor';
import {TabViewModule} from 'primeng/tabview';
import {FileUploadModule} from 'primeng/fileupload';
import {ImageModule} from 'primeng/image';
import {ProgressBarModule} from 'primeng/progressbar';
import {DatePipe} from '@angular/common';
import {AutoComplete, AutoCompleteModule} from 'primeng/autocomplete';
import { FormsModule } from '@angular/forms';
import {ButtonModule} from 'primeng/button';
import {DropdownModule} from 'primeng/dropdown';
import {PanelModule} from 'primeng/panel';
import {TableModule} from 'primeng/table';
import {TreeSelectModule} from 'primeng/treeselect';
import { RoleGuard } from '../../core/auth.guard';
import { Role } from '../../shared/models/Role';
import { DateVNPipe,BytesPipe } from '../../shared/pipes/DateVN.pipe';
import {ChartModule} from 'primeng/chart';
import {CalendarModule} from 'primeng/calendar';
import {InputNumberModule} from 'primeng/inputnumber';
import {TreeTableModule} from 'primeng/treetable';
import { ToastModule } from 'primeng/toast';
import { MessageService } from 'primeng/api';
import { MessagesModule } from 'primeng/messages';
import { MessageModule } from 'primeng/message';
import {SlideMenuModule} from 'primeng/slidemenu';
//object
import { PermisionComponent } from './permision/permision.component'; 
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
import { BackUpComponent } from './back-up/back-up.component';
import { HomePageComponent } from './home-page/home-page.component';
import { OrderReturnComponent } from './order-return/order-return.component';
import { ReportNhapComponent } from './report-nhap/report-nhap.component';
import { ReportXuatComponent } from './report-xuat/report-xuat.component';
import { ReportTonComponent } from './report-ton/report-ton.component';
import { AccDoc_PurchaseComponent } from './acc-doc-purchasae/acc-doc-purchasae.component';
import { AccDocPurchaseCreateComponent } from './acc-doc-purchase-create/acc-doc-purchase-create.component';
import { AccDocSalesComponent } from './acc-doc-sales/acc-doc-sales.component';
import { AccDocSalesEditComponent } from './acc-doc-sales-edit/acc-doc-sales-edit.component';
import { AccDocSalesReturnComponent } from './acc-doc-sales-return/acc-doc-sales-return.component';
import { AccDocPurchaseReturnComponent } from './acc-doc-purchase-return/acc-doc-purchase-return.component';
import { AccDocCashPaymentComponent } from './acc-doc-cash-payment/acc-doc-cash-payment.component';
import { AccDocCashReceiptComponent } from './acc-doc-cash-receipt/acc-doc-cash-receipt.component';
import { OpenCashComponent } from './open-cash/open-cash.component';
import { ProductEditComponent } from './product-edit/product-edit.component';
import { QouComponent } from './qou/qou.component';
import { QouEditComponent } from './qou-edit/qou-edit.component';
import { MenuComponent } from './menu/menu.component';
import { MenuEditComponent } from './menu-edit/menu-edit.component';
import { HomePageEditComponent } from './home-page-edit/home-page-edit.component';

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
        path:'product-edit',
        component: ProductEditComponent,
      },
      {
        path:'product-edit/:id',
        component: ProductEditComponent,
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
        path: 'acc-doc-purchase',
        component: AccDoc_PurchaseComponent,
      },
      {
        path: 'acc-doc-purchase-edit/:id',
        component: AccDocPurchaseCreateComponent,
      },
      {
        path: 'acc-doc-purchase-edit',
        component: AccDocPurchaseCreateComponent,
      },
      {
        path: 'acc-doc-sales',
        component:AccDocSalesComponent,
      },
      {
        path: 'acc-doc-sales-edit/:id',
        component: AccDocSalesEditComponent,
      },
      {
        path: 'acc-doc-sales-edit',
        component: AccDocSalesEditComponent,
      },
      {
        path: 'order',
        component: OrderComponent,
        
      },
      {
        path: 'qou',
        component: QouComponent,
        
      },
      
      {
        path: 'qou-edit/:id',
        component: QouEditComponent,
      },
      {
        path: 'qou-edit',
        component: QouEditComponent,
      },
      {
        path: 'menu',
        component: MenuComponent,
        
      },
   
      {
        path: 'menu-edit',
        component: MenuEditComponent,
      },
      {
        path: 'menu-edit/:id',
        component: MenuEditComponent,
      },

      {
        path: 'home-page',
        component: HomePageComponent,
      },
   
      {
        path: 'home-page-edit',
        component: HomePageEditComponent,
      },
      {
        path: 'home-page-edit/:id',
        component: HomePageEditComponent,
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
      {
        path: 'opent-inventory',
        component: OpeninventoryComponent,
      },
      {
        path: 'customiz-home-page',
        component: HomePageComponent,
      },
      {
        path: 'back-up',
        component: BackUpComponent,
      },
      {
        path: 'order-return',
        component: OrderReturnComponent,
      },
      {
        path: 'report-nhap',
        component: ReportNhapComponent,
      },
      {
        path: 'report-xuat',
        component: ReportXuatComponent,
      },
      {
        path: 'report-ton',
        component: ReportTonComponent,
      },
    ]
  }
]
@NgModule({
  imports: [
    CommonModule,CalendarModule,TreeTableModule,
    MessagesModule,ImageModule,FileUploadModule,
    ProgressBarModule,SlideMenuModule,
    MessageModule ,
    ToastModule,
    SharedModule,
    InputNumberModule,
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
  providers: [
    DatePipe,MessageService
  ],
  bootstrap:  [ MainComponent ],
  declarations: [MainComponent,    
    DashboardComponent ,BytesPipe, DateVNPipe, PermisionComponent, AccDocComponent, AccDocDetailComponent, OpenInventoryComponent, OpenInventorySystemComponent, LoginEventComponent, PostCategoryComponent, PostComponent, ProductCategoryComponent, ProductComponent, ManufacturerComponent, SlideComponent, EmployeeComponent, CustomerComponent, AppUserComponent, AccDocProductComponent,OrderComponent, EventlogComponent, LogerrorComponent, OpeninventoryComponent, BackUpComponent, HomePageComponent, OrderReturnComponent, ReportNhapComponent, ReportXuatComponent, ReportTonComponent, AccDoc_PurchaseComponent, AccDocPurchaseCreateComponent, AccDocSalesComponent, AccDocSalesEditComponent, AccDocSalesReturnComponent, AccDocPurchaseReturnComponent, AccDocCashPaymentComponent, AccDocCashReceiptComponent, OpenCashComponent, ProductEditComponent, QouComponent, QouEditComponent, MenuComponent, MenuEditComponent, HomePageEditComponent]
})
export class MainModule { }
