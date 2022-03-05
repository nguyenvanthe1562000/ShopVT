import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './pages/shopping/login/login.component';
import { PageNotFoundComponent } from './shared/component/page-not-found/page-not-found.component';


const routes: Routes = [
  { path: '', loadChildren: () => import('./pages/main/main.module').then(m => m.MainModule)} ,
  { path: 'shopping', loadChildren: () => import('./pages/shopping/shopping.module').then(m => m.ShoppingModule)} ,
  
  {
    path: '**',
    component: PageNotFoundComponent,
  },  
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
