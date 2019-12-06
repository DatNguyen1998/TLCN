import { Component, OnInit } from '@angular/core';
import { BillDetailService } from 'src/app/services/bill/bill-detail.service';
import { AuthenticationService } from 'src/app/services/common/authentication.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  carts: any[] =[];

  tableInfo = {
    loading: false,
    pageIndex: 1,
    total: 0,
    pageSize: 10,
  }

  model = {
    authUserId: ''
  }

  constructor(
    private billDetailSv?: BillDetailService,
    private authenSv?: AuthenticationService
  ) { }

  ngOnInit() {
    this.getCart();
  }

  async getCart() {
    try {
      this.tableInfo.loading = true;
      this.model.authUserId = this.authenSv.currentUser.userId;
      const res: any = await  this.billDetailSv.GetProductForClient(this.model);
      this.carts = res;
    }
    catch(e) {
      console.log(e);
    }
    finally {
      this.tableInfo.loading = false;
    }
  }


  deleteRow(id: any) {

  }

}
