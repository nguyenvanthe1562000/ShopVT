import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TopbarComponent } from './components/topbar/topbar.component';
import { LeftSlidebarComponent } from './components/left-slidebar/left-slidebar.component';
import { RouterModule } from '@angular/router';
import { UnauthorizedComponent } from './components/unauthorized/unauthorized.component';


@NgModule({
  imports: [
    CommonModule,
    RouterModule
  ],
  declarations: [TopbarComponent, LeftSlidebarComponent, UnauthorizedComponent],
  exports: [
    TopbarComponent, LeftSlidebarComponent
  ]
})
export class SharedModule { }
