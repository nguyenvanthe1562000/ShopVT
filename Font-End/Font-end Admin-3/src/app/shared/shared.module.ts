import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TopbarComponent } from './components/topbar/topbar.component';
import { LeftSlidebarComponent } from './components/left-slidebar/left-slidebar.component';
import { RouterModule } from '@angular/router';
import { UnauthorizedComponent } from './components/unauthorized/unauthorized.component';
import { ToastModule } from 'primeng/toast';
import { MessageService } from 'primeng/api';
import { MessagesModule } from 'primeng/messages';
import { MessageModule } from 'primeng/message';
//object

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    MessagesModule,
    MessageModule ,
    ToastModule,
  ],
  providers: [
    MessageService
  ],
  declarations: [TopbarComponent, LeftSlidebarComponent, UnauthorizedComponent],
  exports: [
    TopbarComponent, LeftSlidebarComponent
  ]
})
export class SharedModule { }
