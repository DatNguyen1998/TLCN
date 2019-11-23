import { Component, OnInit } from '@angular/core';
import { NzModalService, NzMessageService } from 'ng-zorro-antd';
import { AuthUserDetailComponent } from '../auth-user-detail/auth-user-detail.component';

@Component({
  selector: 'app-auth-user-list',
  templateUrl: './auth-user-list.component.html',
  styleUrls: ['./auth-user-list.component.css']
})
export class AuthUserListComponent implements OnInit {

    tableInfo = {
        loading: false,
        pageIndex: 1,
        total: 0,
        pageSize: 10,
        keyWord: '',
    }

    authUsers: any[] = [];

    constructor(
        private modalService: NzModalService,
        private msg?: NzMessageService,
    ) { }

    ngOnInit() {

    }

    getList() {

    }

    edit(model: any = null) {
        const addModal = 'Thêm khách hàng';
        const editModal = 'Sửa khách hàng';
        const modal = this.modalService.create({
            nzTitle: model && model.id ? editModal : addModal,
            nzMaskClosable: false,
            nzWidth: 800,
            nzContent: AuthUserDetailComponent,
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

    search() {

    }

}
