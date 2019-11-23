import { Component, OnInit } from '@angular/core';
import { NzMessageService, NzModalService } from 'ng-zorro-antd';
import { MetadataTypeDetailComponent } from '../metadata-type-detail/metadata-type-detail.component';

@Component({
  selector: 'app-metadata-type-list',
  templateUrl: './metadata-type-list.component.html',
  styleUrls: ['./metadata-type-list.component.css']
})
export class MetadataTypeListComponent implements OnInit {

    tableInfo = {
        loading: false,
        pageIndex: 1,
        total: 0,
        pageSize: 10,
        keyWord: '',
    }

    metadataTypes: any[] = [];

    constructor(
        private modalService: NzModalService,
        private msg?: NzMessageService,
    )
    { }

    ngOnInit() {

    }

    getList() {

    }

    edit(model: any = null) {
        const addModal = 'Thêm loại Metadata';
        const editModal = 'Sửa loại Metadata';
        const modal = this.modalService.create({
            nzTitle: model && model.id ? editModal : addModal,
            nzMaskClosable: false,
            nzWidth: 800,
            nzContent: MetadataTypeDetailComponent,
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

}
