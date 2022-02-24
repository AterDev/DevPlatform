import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'index' },
  { path: 'docs', pathMatch: 'full', redirectTo: 'docs' },
  { path: 'docs-catalog', pathMatch: 'full', redirectTo: 'docs-catalog' },
  { path: '*', pathMatch: 'full', redirectTo: 'index' },
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
