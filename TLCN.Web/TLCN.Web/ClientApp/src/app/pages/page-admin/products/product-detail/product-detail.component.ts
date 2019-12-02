import { Component, OnInit, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NzModalRef, NzMessageService, UploadFile } from 'ng-zorro-antd';
import { ProductService } from 'src/app/services/product/product.service';
import { MetadataValueService } from 'src/app/services/metadataValue/metadata-value.service';
import { MetadataTypeEnum } from 'src/app/enum/MetadataType.enum';
import { MenuService } from 'src/app/services/menu/menu.service';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {

    @Input() params: any;

    productForm: FormGroup;

    isLoading = false;
    producers: any[] = [];
    productTypes: any[] = [];

    nodes: any[] = [];
    menus: any[] = [];

    logos: any = {
        "Logo": {
            filesToUpload: [],
            downloading: false,
            uploading: false,
            base64Image: ''
        }
    }

    modelSearch = {
        name: '',
        field: '',
        id: '',
    }

    constructor(
        private fb: FormBuilder,
        private modal: NzModalRef,
        private msg?: NzMessageService,
        private productSv?: ProductService,
        private metaValueSv?: MetadataValueService,
        private menuSv?: MenuService,
    ) { }

    ngOnInit() {
        this.productForm = this.fb.group({
            id: ['3761607a-a17b-40c8-bfcc-6658fac1ac8d'],
            code: [, [Validators.required]],
            name: [, [Validators.required]],
            producerId: [, [Validators.required]],
            menuId: [, [Validators.required]],
            price: [, [Validators.required]],
            description: [, [Validators.required]],
            isSell: [true],
            logoId: []
        });

        this.getDataProducer();
        this.getDataForTree();
        if(this.params.id !== '') {
            this.getById();
        }
    }

    async getById() {
        try {
            this.modelSearch.id = this.params.id;
            const res = await this.productSv.getById(this.modelSearch);
            this.productForm.patchValue(res);
        }
        catch (e) {
            console.log(e);
        }
      } 

    save() {
        if (!this.productForm.invalid) {
            if (this.params.id === '') {
                const res = this.productSv.add(this.productForm.value);
                if (res) {
                    this.msg.success('Thêm thành công');
                    this.modal.destroy();
                }
            }
            else {
                const res = this.productSv.update(this.productForm.value);
                if (res) {
                    this.msg.success('Sửa thành công');
                    this.modal.destroy();
                }
            }
        }
        else {
            this.validateData(this.productForm);
        }
    }

    async getDataProducer() {
        try {
            this.modelSearch.field = MetadataTypeEnum.PRODUCER;
            const resProvince = await this.metaValueSv.filter(this.modelSearch);
            this.producers = resProvince;
            this.producers.sort(function(a, b) {
                var textA = a.name.toUpperCase();
                var textB = b.name.toUpperCase();
                return (textA < textB) ? -1 : (textA > textB) ? 1 : 0;
            });
        }
        catch(e) {
            console.log(e);
        }
        finally {
            this.modelSearch.field = '';
        }
    }

    cancel() {
        this.modal.destroy();
    }

    async getDataForTree() {
        try {
          this.nodes = [];
            this.isLoading = true;
            const res: any = await this.menuSv.getAll();
            this.menus = res;
            this.createTree();
            
        }
        catch(e) {
            console.log(e);
        }
        finally {
            this.isLoading = false;
        }
    }

    createTree() {
        this.menus.forEach(item => {
          if(item.parentId === null) {
            this.nodes = [...this.nodes, {title: item.name, key: item.id, expanded: true ,level: 0, checked: true  , children: [] }];
            this.addChildren(this.nodes[this.nodes.length - 1]);
          }
        });
    }
    
      
    addChildren(node: any) {
        this.menus.forEach(item => {
          if(node.key === item.parentId) {
            node.children = [...node.children, {title: item.name, key: item.id , children: [], expanded: true, level: node.level + 1}];
            this.addChildren(node.children[node.children.length - 1]);
          }
        });
    }

    validateData(form: any) {
        for (const i in form.controls) {
            form.controls[i].markAsDirty();
            form.controls[i].updateValueAndValidity();
        }
    }

    showExplain(formControlName: string, errorString?: string) {
        return this.productForm.get(formControlName).dirty && this.productForm.get(formControlName).errors
            && this.productForm.get(formControlName).errors[errorString];
    }

    //upload file
    beforeUploadLogo = (file: UploadFile): boolean => {
        return this.beforeUpload(file, 'Logo');
    };

    beforeUpload(file: UploadFile, type: string) {
        this.logos[type].filesToUpload = [];
        this.logos[type].filesToUpload = [...this.logos[type].filesToUpload, file]; // allow 1 file only
        return false;
    }

    async handleUpload(logoType: string) {
        const formData = new FormData();
        this.logos[logoType].filesToUpload.forEach((file: any) => {
            formData.append('files[]', file);
        });

        // Upload file
        this.logos[logoType].uploading = true;
        //const res = await this.attachmentService.upload(formData);
        this.logos[logoType].uploading = false;

        //if (res && res.data && res.data.length) {

        //    this.logos[logoType].filesToUpload = [];
        //    const uploadedFile = res.data[0];

        //    if (logoType === 'Logo') {
        //        this.validateForm.controls.logoId.setValue(uploadedFile.id);
        //    }

        //    // Get base 64 image
        //    this.logos[logoType].downloading = true;
        //    const base64image = await this.getBase64Image(uploadedFile.id);
        //    if (base64image) {
        //        this.logos[logoType].base64Image = base64image;
        //    }
        //    else {
        //        this.logos[logoType].base64Image = '';
        //    }
        //    this.logos[logoType].downloading = false;

        //}
    }


}
