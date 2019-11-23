import { Component, OnInit, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { NzModalRef, NzMessageService } from 'ng-zorro-antd';

@Component({
  selector: 'app-auth-user-detail',
  templateUrl: './auth-user-detail.component.html',
  styleUrls: ['./auth-user-detail.component.css']
})
export class AuthUserDetailComponent implements OnInit {

    @Input() params: any;

    authUserForm: FormGroup;

    genders: any[] = [];
    provinces: any[] = [];
    districts: any[] = [];

    districtLoading = false;
    districtDisable = true;
    isLoading = false;  // loading chung


    constructor(
        private fb: FormBuilder,
        private modal: NzModalRef,
        private msg?: NzMessageService,
    ) { }

    ngOnInit() {
        this.authUserForm = this.fb.group({
            id: ['3761607a-a17b-40c8-bfcc-6658fac1ac8d'],
            code: [, [Validators.required]],
            fullname: [, [Validators.required]],
            username: [, [Validators.required]],
            password: [, [Validators.required]],
            email: [, [Validators.required]],
            confirmPassword: [, [Validators.required], this.checkConfirmPassWordValidator],
            birthDate: [, [Validators.required]],
            genderId: [, [Validators.required]],
            phoneNumber: [, [Validators.required]],
            address: [, [Validators.required]],
            role: [, [Validators.required]],
            districtId: [, [Validators.required]],
            provinceId: [, [Validators.required]],
            isActivated: [true],
        });
    }

    cancel() {
        this.modal.destroy();
    }

    save() {
        if (!this.authUserForm.invalid) {

        }
        else {
            this.validateData(this.authUserForm);
        }
    }

    search() {

    }

    provinceOnchanges() {

    }

    validateData(form: any) {
        for (const i in form.controls) {
            form.controls[i].markAsDirty();
            form.controls[i].updateValueAndValidity();
        }
    }

    showExplain(formControlName: string, errorString?: string) {
        return this.authUserForm.get(formControlName).dirty && this.authUserForm.get(formControlName).errors
            && this.authUserForm.get(formControlName).errors[errorString];
    }

    checkConfirmPassWordValidator = (control: FormControl): { [s: string]: boolean } => {
        if (!control.value) {
            return { required: true };
        } else if (control.value !== this.authUserForm.controls.password.value) {
            return { confirm: true, error: true };
        }
        return {};
    };

}
