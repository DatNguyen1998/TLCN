import { Component, OnInit } from '@angular/core';
import { NzModalService, NzMessageService } from 'ng-zorro-antd';
import { PromotionDetailComponent } from '../promotion-detail/promotion-detail.component';

@Component({
  selector: 'app-promotion-list',
  templateUrl: './promotion-list.component.html',
  styleUrls: ['./promotion-list.component.css']
})
export class PromotionListComponent implements OnInit {

    tableInfo = {
        loading: false,
        pageIndex: 1,
        total: 0,
        pageSize: 10,
        keyWord: '',
    }

    promotions: any[] = [];

    constructor(
        private modalService: NzModalService,
        private msg?: NzMessageService,
    ) { }

    ngOnInit() {

    }

    edit(model: any = null) {
        const addModal = 'Thêm khuyến mãi';
        const editModal = 'Sửa khuyến mãi';
        const modal = this.modalService.create({
            nzTitle: model && model.id ? editModal : addModal,
            nzMaskClosable: false,
            nzWidth: 800,
            nzContent: PromotionDetailComponent,
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

    getList() {

    }

    deleteRow() {

    }

}
