import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/services/common/authentication.service';
import { Router } from '@angular/router';
import { MenuService } from 'src/app/services/menu/menu.service';
import { BillDetailService } from 'src/app/services/bill/bill-detail.service';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {

  userName = '';

  
  nodes: any[] = [];
  menus: any[] = [];

  constructor(
    private authenSv: AuthenticationService,
    private router?: Router,
    private menuSv?: MenuService,
    private billDetailSv?: BillDetailService,
  ) { }

  ngOnInit() {
    var check = this.authenSv.isLogin();
    if (!check) {
      this.router.navigate(['/login']);
    }
    this.userName = this.authenSv.currentUser.name;
    this.getDataForTree();
  }

  async getDataForTree() {
    try {
      this.nodes = [];
      const res: any = await this.menuSv.getAll();
      this.menus = res;
      this.createTree();
      this.getCart();
    }
    catch(e) {
        console.log(e);
    }
  }

  createTree() {
    this.menus.forEach(item => {
      if(item.parentId === null) {
        this.nodes = [...this.nodes, {title: item.name, key: item.id, code: item.code, level: 0, children: [] }];
        this.addChildren(this.nodes[this.nodes.length - 1]);
      }
    });
  }

  
  addChildren(node: any) {
    this.menus.forEach(item => {
      if(node.key === item.parentId) {
        node.children = [...node.children, {title: item.name, key: item.id , children: [], code: item.code, level: node.level + 1}];
        this.addChildren(node.children[node.children.length - 1]);
      }
    });
    
  }

  logout() {
    this.authenSv.logout();
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
