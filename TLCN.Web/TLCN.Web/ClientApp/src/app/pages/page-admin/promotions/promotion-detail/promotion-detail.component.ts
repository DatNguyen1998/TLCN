import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NzModalRef, NzMessageService } from 'ng-zorro-antd';

@Component({
  selector: 'app-promotion-detail',
  templateUrl: './promotion-detail.component.html',
  styleUrls: ['./promotion-detail.component.css']
})
export class PromotionDetailComponent implements OnInit {

    @Input() params: any;

    promotionForm: FormGroup;

    constructor(
        private fb: FormBuilder,
        private modal: NzModalRef,
        private msg?: NzMessageService,
    ) { }

    ngOnInit() {
        this.promotionForm = this.fb.group({
            id: ['3761607a-a17b-40c8-bfcc-6658fac1ac8d'],
            code: [, [Validators.required]],
            name: [, [Validators.required]],
            disCount: [, [Validators.required]],
            description: [, [Validators.required]],
        });
    }

    save() {
        if(!this.promotionForm.invalid) {

        }
        else {
            this.validateData(this.promotionForm);
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
        return this.promotionForm.get(formControlName).dirty && this.promotionForm.get(formControlName).errors
            && this.promotionForm.get(formControlName).errors[errorString];
    }
}
