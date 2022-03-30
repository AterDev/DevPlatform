import { NgModule } from '@angular/core';
import { HomeRoutingModule } from './home-routing.module';
import { ComponentsModule } from 'src/app/components/components.module';
import { ShareModule } from 'src/app/share/share.module';
import { IndexComponent } from './index/index.component';
import { LayoutComponent } from './layout/layout.component';


@NgModule({
  declarations: [
    IndexComponent,
    LayoutComponent
  ],
  imports: [
    ComponentsModule,
    ShareModule,
    HomeRoutingModule
  ]
})
export class HomeModule { }
