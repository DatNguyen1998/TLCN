import { Component, OnInit, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NzModalRef, NzMessageService, UploadFile } from 'ng-zorro-antd';

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

    logos: any = {
        "Logo": {
            filesToUpload: [],
            downloading: false,
            uploading: false,
            base64Image: ''
        }
    }

    constructor(
        private fb: FormBuilder,
        private modal: NzModalRef,
        private msg?: NzMessageService,
    ) { }

    ngOnInit() {
        this.productForm = this.fb.group({
            id: ['3761607a-a17b-40c8-bfcc-6658fac1ac8d'],
            code: [, [Validators.required]],
            name: [, [Validators.required]],
            producerId: [, [Validators.required]],
            productTypeId: [, [Validators.required]],
            price: [, [Validators.required]],
            description: [, [Validators.required]],
            isSell: [true],
            logoId: []
        });
    }

    save() {
        if (!this.productForm.invalid) {

        }
        else {
            this.validateData(this.productForm);
        }
    }

    cancel() {
        this.modal.destroy();
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
