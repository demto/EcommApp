import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { config } from 'process';
import { environment } from 'src/environments/environment';
import { Address } from '../shared/models/address';
import { DeliveryMethod } from '../shared/models/deliveryMethod';
import { Order } from '../shared/models/order';

@Injectable({
  providedIn: 'root'
})
export class OrdersService {

  baseUrl = environment.apiUrl;

  constructor(private httpClient: HttpClient) { }


  getOrders() {
    return this.httpClient.get(this.baseUrl + 'orders/getOrders');
  }

  getOrder(id: number) {
    return this.httpClient.get(this.baseUrl + 'orders/getOrder/' + id);
  }

  // submitOrder(basketId: number, deliveryMethod: DeliveryMethod, shipToAddress: Address) {
  //   return this.httpClient.post<Order>(this.baseUrl + 'orders', {basketId, deliveryMethod, shipToAddress});
  // }
}
