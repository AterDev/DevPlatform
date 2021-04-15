import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '', redirectTo: 'index', pathMatch: 'full' },
  { path: 'index', redirectTo: 'index', pathMatch: 'full' },
  { path: 'signin-oidc', redirectTo: 'login', pathMatch: 'full' },
  { path: 'signout-callback-oidc', redirectTo: 'index', pathMatch: 'full' },
  { path: 'signout-oidc', redirectTo: 'index', pathMatch: 'full' },
  { path: 'login', redirectTo: 'login', pathMatch: 'full' },
  { path: '*', redirectTo: '', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
