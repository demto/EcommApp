import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { OrdersListComponent } from './orders-list/orders-list.component';
import { OrdersDetailsComponent } from './orders-details/orders-details.component';

const routes = [
    {path: '', component: OrdersListComponent},
    {path: ':id', component: OrdersDetailsComponent}
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
  })
  export class OrdersRoutingModule { }
