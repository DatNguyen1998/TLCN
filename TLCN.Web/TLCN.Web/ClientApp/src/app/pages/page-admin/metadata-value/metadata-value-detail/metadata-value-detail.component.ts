import { Component, OnInit, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NzModalRef, NzMessageService } from 'ng-zorro-antd';

@Component({
  selector: 'app-metadata-value-detail',
  templateUrl: './metadata-value-detail.component.html',
  styleUrls: ['./metadata-value-detail.component.css']
})
export class MetadataValueDetailComponent implements OnInit {

    @Input() params: any;

    metadataValueForm: FormGroup;

    isLoading = false;
    metadataTypes: any[] = [];

    constructor(
        private fb: FormBuilder,
        private modal: NzModalRef,
        private msg?: NzMessageService,
    ) { }

    ngOnInit() {
        this.metadataValueForm = this.fb.group({
            id: ['3761607a-a17b-40c8-bfcc-6658fac1ac8d'],
            code: [, [Validators.required]],
            name: [, [Validators.required]],
            typeId: ['', [Validators.required]]
        });
    }

    cancel() {
        
    }

    save() {
        if (!this.metadataValueForm.invalid) {

        }
        else {
            this.validateData(this.metadataValueForm);
        }
    }

    validateData(form: any) {
        for (const i in form.controls) {
            form.controls[i].markAsDirty();
            form.controls[i].updateValueAndValidity();
        }
    }

    showExplain(formControlName: string, errorString?: string) {
        return this.metadataValueForm.get(formControlName).dirty && this.metadataValueForm.get(formControlName).errors
            && this.metadataValueForm.get(formControlName).errors[errorString];
    }

}
