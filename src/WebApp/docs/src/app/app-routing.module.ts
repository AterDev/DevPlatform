import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'index' },
  { path: 'login', component: LoginComponent },
  { path: 'docs', pathMatch: 'full', redirectTo: 'docs' },
  { path: 'config', pathMatch: 'full', redirectTo: 'config' },
  { path: 'docs-catalog', pathMatch: 'full', redirectTo: 'docs-catalog' },
  { path: '*', pathMatch: 'full', redirectTo: 'index' },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
