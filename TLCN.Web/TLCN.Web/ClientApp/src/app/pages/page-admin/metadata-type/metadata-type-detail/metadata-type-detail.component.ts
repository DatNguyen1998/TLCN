import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NzModalRef, NzMessageService } from 'ng-zorro-antd';

@Component({
  selector: 'app-metadata-type-detail',
  templateUrl: './metadata-type-detail.component.html',
  styleUrls: ['./metadata-type-detail.component.css']
})
export class MetadataTypeDetailComponent implements OnInit {

    @Input() params: any;

    metadataTypeForm: FormGroup;

    constructor(
        private fb: FormBuilder,
        private modal: NzModalRef,
        private msg?: NzMessageService,
    )
    { }

    ngOnInit() {
        this.metadataTypeForm = this.fb.group({
            id: ['3761607a-a17b-40c8-bfcc-6658fac1ac8d'],
            code: [, [Validators.required]],
            name: [, [Validators.required]],
        });
    }

    cancel() {

    }

    save() {
        if (!this.metadataTypeForm.invalid) {

        }
        else {
            this.validateData(this.metadataTypeForm);
        }
    }

    validateData(form: any) {
        for (const i in form.controls) {
            form.controls[i].markAsDirty();
            form.controls[i].updateValueAndValidity();
        }
    }

    showExplain(formControlName: string, errorString?: string) {
        return this.metadataTypeForm.get(formControlName).dirty && this.metadataTypeForm.get(formControlName).errors
            && this.metadataTypeForm.get(formControlName).errors[errorString];
    }

}
