import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IProduct } from './shared/models/product';
import { IPagination } from './shared/models/pagination';
import { BasketService } from './basket/basket.service';
import { AccountService } from './account/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  title = 'ECommApp';

  constructor(private basketService: BasketService, private accountService: AccountService) { }

  ngOnInit(): void {
    this.loadBasket();
    this.loadUser();
  }

  loadBasket() {
    const basketId = localStorage.getItem('basket_id');
    this.basketService.getBasket(basketId)
      .subscribe(() => {
        console.log('Basket is initialised');
        console.log(this.basketService.getCurrentBasketValue().items);
      }, error => {
        console.log(error);
      });
  }

  loadUser() {
    const userToken = localStorage.getItem('token');
    if (userToken) {
      this.accountService.loadCurrentUser(userToken).subscribe(() => {
        console.log('User has been loaded.');
      }, error => {
        console.log('Usrr could not be loaded.');
      });
    }
  }
}
