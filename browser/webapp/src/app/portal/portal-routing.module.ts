import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from '../auth.guard';
import { IndexComponent } from './index/index.component';
import { PortalLayoutComponent } from './portal-layout/portal-layout.component';

const routes: Routes = [
  {
    path: 'portal',
    canActivate: [AuthGuard],
    component: PortalLayoutComponent,
    children: [
      {
        path: '',
        canActivateChild: [AuthGuard],
        children: [
          { path: '', pathMatch: 'full', redirectTo: 'index' },
          { path: 'index', component: IndexComponent },
          { path: 'article', pathMatch: 'full', redirectTo: 'article' },
          { path: 'code-snippet', pathMatch: 'full', redirectTo: 'code-snippet' },
        ]
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PortalRoutingModule { }
