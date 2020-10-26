import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Order } from 'src/app/shared/models/order';
import { OrdersService } from '../orders.service';

@Component({
  selector: 'app-orders-list',
  templateUrl: './orders-list.component.html',
  styleUrls: ['./orders-list.component.scss']
})
export class OrdersListComponent implements OnInit {

  orders: Order[];

  constructor(private ordersService: OrdersService,
              private toastrService: ToastrService,
              private router: Router) { }

  ngOnInit() {
    this.ordersService.getOrders().subscribe((orders: Order[]) => {
      this.orders = orders;
    }, error => {
      this.toastrService.error(error);
    });
  }

  selectRow(id: number) {
    console.log(id);
    this.router.navigate(['/orders', id]);
  }

}
