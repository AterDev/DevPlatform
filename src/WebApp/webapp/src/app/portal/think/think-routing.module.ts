import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from 'src/app/auth.guard';
import { IndexComponent } from './index/index.component';
import { AddComponent } from './add/add.component';
import { DetailComponent } from './detail/detail.component';
import { EditComponent } from './edit/edit.component';
import { PortalLayoutComponent } from '../portal-layout/portal-layout.component';

const routes: Routes = [
  {
    path: 'portal/think',
    component: PortalLayoutComponent,
    canActivate: [AuthGuard],
    children:
      [
        {
          path: '',
          canActivateChild: [AuthGuard],
          children: [
            { path: '', pathMatch: 'full', redirectTo: 'index' },
            { path: 'index', component: IndexComponent },
            { path: 'add', component: AddComponent },
            { path: 'detail/:id', component: DetailComponent },
            { path: 'edit/:id', component: EditComponent },
          ]
        }
      ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ThinkRoutingModule { }
