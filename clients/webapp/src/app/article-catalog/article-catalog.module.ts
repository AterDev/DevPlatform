import { NgModule } from '@angular/core';
import { ArticleCatalogRoutingModule } from './article-catalog-routing.module';
import { ShareModule } from '../share/share.module';
import { IndexComponent } from './index/index.component';
import { DetailComponent } from './detail/detail.component';
import { LayoutComponent } from './layout/layout.component';
import { AddComponent } from './add/add.component';
import { EditComponent } from './edit/edit.component';

@NgModule({
  declarations: [IndexComponent, DetailComponent, LayoutComponent, AddComponent, EditComponent],
  imports: [
    ShareModule,
    ArticleCatalogRoutingModule
  ]
})
export class ArticleCatalogModule { }
