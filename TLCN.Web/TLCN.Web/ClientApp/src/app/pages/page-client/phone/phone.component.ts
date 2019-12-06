import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductService } from 'src/app/services/product/product.service';
import { BillDetailService } from 'src/app/services/bill/bill-detail.service';
import { FormGroup, FormBuilder } from '@angular/forms';
import { TouchSequence } from 'selenium-webdriver';
import { AuthenticationService } from 'src/app/services/common/authentication.service';

@Component({
  selector: 'app-phone',
  templateUrl: './phone.component.html',
  styleUrls: ['./phone.component.css']
})
export class PhoneComponent implements OnInit {

  menuCode = '';
  products: any[] = [];

  modelSearch = {
    menuCode: '',
  }

  cartForm: FormGroup;


  constructor(
    private route: ActivatedRoute,
    private productSv?: ProductService,
    private billDetailSv?: BillDetailService,
    private fb?: FormBuilder,
    private authenSv?: AuthenticationService
  ) { }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.menuCode = params.get('productCode');
      this.getProduct();
      this.initForm();
      this.getCart();
    });
  }

  initForm() {
    this.cartForm = this.fb.group({
      id: ['3761607a-a17b-40c8-bfcc-6658fac1ac8d'],
      ProductId: [],
      Amount: [1],
      PriceTotal: [0],
      AuthUserId: [],
    });
  }

  async getProduct() {
    try {
        this.modelSearch.menuCode = this.menuCode;
      const res = await this.productSv.getProductForClient(this.modelSearch);
      this.products = res;
    }
    catch(e) {
      console.log(e);
    }
  }

  addCart(productId: any) {
    try {
      this.cartForm.controls.ProductId.setValue(productId);
      this.cartForm.controls.AuthUserId.setValue(this.authenSv.currentUser.userId);
      const res = this.billDetailSv.add(this.cartForm.value);
    }
    catch(e) {
      console.log(e);
    }
    finally {
      this.getCart();
    }
  }

  async getCart() {
    try {
      const res: any = await this.billDetailSv.getAll();
      this.authenSv.countCart = res.length;
    }
    catch(e) {
      console.log(e);
    }
  }

  

}
