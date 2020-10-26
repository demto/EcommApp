import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, RouterStateSnapshot } from '@angular/router';
import { Order } from 'src/app/shared/models/order';
import { OrdersService } from '../orders.service';

@Component({
  selector: 'app-orders-details',
  templateUrl: './orders-details.component.html',
  styleUrls: ['./orders-details.component.scss']
})
export class OrdersDetailsComponent implements OnInit {

  order: Order;

  constructor(private orderService: OrdersService,
              private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.orderService.getOrder(this.activatedRoute.snapshot.params['id']).subscribe((order: Order) => 
      this.order = order);
  }

}
