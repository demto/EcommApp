import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrdersListComponent } from './orders-list/orders-list.component';
import { OrdersDetailsComponent } from './orders-details/orders-details.component';
import { SharedModule } from '../shared/shared.module';
import { OrdersRoutingModule } from './orders-routing.module';
import { CoreModule } from '../core/core.module';



@NgModule({
  declarations: [OrdersListComponent, OrdersDetailsComponent],
  imports: [
    SharedModule,
    CommonModule
  ],
  exports: [
    OrdersRoutingModule
  ]
})
export class OrdersModule { }
