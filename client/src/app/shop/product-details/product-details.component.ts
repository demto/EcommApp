import { Component, OnInit } from '@angular/core';
import { IProduct } from 'src/app/shared/models/product';
import { ShopService } from '../shop.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {

  product: IProduct;

  constructor(private shopService: ShopService,
              private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.getProduct();
  }

  getProduct() {
    this.shopService.getProduct(this.activatedRoute.snapshot.params['id']).subscribe(product => {
      this.product = product;
    });
  }

}