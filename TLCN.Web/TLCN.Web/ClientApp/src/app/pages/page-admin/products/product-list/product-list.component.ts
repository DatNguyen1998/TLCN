import { Component, OnInit } from '@angular/core';
import { NzModalService, NzMessageService } from 'ng-zorro-antd';
import { ProductDetailComponent } from '../product-detail/product-detail.component';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

    tableInfo = {
        loading: false,
        pageIndex: 1,
        total: 0,
        pageSize: 10,
        keyWord: '',
    }

    selectedProductType = '';
    selectedProducer = '';

    productTypes: any[] = [];
    producers: any[] = [];
    products: any[] = [];

    constructor(
        private modalService: NzModalService,
        private msg?: NzMessageService,
    ) { }

    ngOnInit() {

    }

    getList() {

    }

    edit(model: any = null) {
        const addModal = 'Thêm sản phẩm';
        const editModal = 'Sửa sản phẩm';
        const modal = this.modalService.create({
            nzTitle: model && model.id ? editModal : addModal,
            nzMaskClosable: false,
            nzWidth: 800,
            nzContent: ProductDetailComponent,
            nzComponentParams: {
                params: {
                    id: model ? model._id : '',
                }
            },
            nzFooter: [{
                label: 'Hủy bỏ',
                onClick: (component) => {
                    component.cancel();
                }
            },
            {
                label: 'Lưu',
                type: 'primary',
                onClick: (component) => {
                    component.save();
                }
            }]
        });
        modal.afterClose.subscribe((result) => {
            this.getList();
        });
    }

    deleteRow() {

    }



}
