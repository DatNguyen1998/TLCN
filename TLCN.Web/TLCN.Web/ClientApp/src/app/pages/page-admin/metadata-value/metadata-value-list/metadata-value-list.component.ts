import { Component, OnInit } from '@angular/core';
import { NzModalService, NzMessageService } from 'ng-zorro-antd';
import { MetadataValueDetailComponent } from '../metadata-value-detail/metadata-value-detail.component';

@Component({
  selector: 'app-metadata-value-list',
  templateUrl: './metadata-value-list.component.html',
  styleUrls: ['./metadata-value-list.component.css']
})
export class MetadataValueListComponent implements OnInit {

    tableInfo = {
        loading: false,
        pageIndex: 1,
        total: 0,
        pageSize: 10,
        keyWord: '',
    }

    metadataValues: any[] = [];
    metadataTypes: any[] = [];

    selectedMetadataType = '';

    constructor(
        private modalService: NzModalService,
        private msg?: NzMessageService,
    ) { }

    ngOnInit() {

    }

    getList() {

    }

    edit(model: any = null) {
        const addModal = 'Thêm Metadata';
        const editModal = 'Sửa Metadata';
        const modal = this.modalService.create({
            nzTitle: model && model.id ? editModal : addModal,
            nzMaskClosable: false,
            nzWidth: 800,
            nzContent: MetadataValueDetailComponent,
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
