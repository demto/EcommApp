import { Component, OnInit, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Address } from 'cluster';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from 'src/app/account/account.service';

@Component({
  selector: 'app-checkout-address',
  templateUrl: './checkout-address.component.html',
  styleUrls: ['./checkout-address.component.scss']
})
export class CheckoutAddressComponent implements OnInit {

  @Input() checkoutForm: FormGroup;

  constructor(private accountService: AccountService, private toaster: ToastrService) { }

  ngOnInit() {
  }

  saveAddress() {
    this.accountService.updateUserAddress(this.checkoutForm.get('addressForm').value).subscribe((address) => {
      this.checkoutForm.get('addressForm').reset(address);
      this.toaster.success('Address saved');
    }, error => {
      this.toaster.error(error);
    });
  }

}
