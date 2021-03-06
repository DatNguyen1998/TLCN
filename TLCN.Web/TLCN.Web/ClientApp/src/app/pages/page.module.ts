import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { NgZorroAntdModule, NZ_I18N, en_US } from 'ng-zorro-antd';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { registerLocaleData } from '@angular/common';
import en from '@angular/common/locales/en';
import { RouterModule } from '@angular/router';
import { WelcomeAdminComponent } from './page-admin/welcome-admin/welcome-admin/welcome-admin.component';
import { AuthUserListComponent } from './page-admin/auth-users/auth-user-list/auth-user-list.component';
import { BillListComponent } from './page-admin/bills/bill-list/bill-list.component';
import { CartListComponent } from './page-admin/carts/cart-list/cart-list.component';
import { MetadataTypeListComponent } from './page-admin/metadata-type/metadata-type-list/metadata-type-list.component';
import { MetadataValueListComponent } from './page-admin/metadata-value/metadata-value-list/metadata-value-list.component';
import { ProductListComponent } from './page-admin/products/product-list/product-list.component';
import { PromotionListComponent } from './page-admin/promotions/promotion-list/promotion-list.component';
import { AuthUserDetailComponent } from './page-admin/auth-users/auth-user-detail/auth-user-detail.component';
import { BillDetailComponent } from './page-admin/bills/bill-detail/bill-detail.component';
import { CartDetailComponent } from './page-admin/carts/cart-detail/cart-detail.component';
import { MetadataTypeDetailComponent } from './page-admin/metadata-type/metadata-type-detail/metadata-type-detail.component';
import { MetadataValueDetailComponent } from './page-admin/metadata-value/metadata-value-detail/metadata-value-detail.component';
import { ProductDetailComponent } from './page-admin/products/product-detail/product-detail.component';
import { PromotionDetailComponent } from './page-admin/promotions/promotion-detail/promotion-detail.component';
import { LoginComponent } from './login/login.component';
import { JwtInterceptor } from '../services/helper/Jwt.Interceptor';
import { MenuListComponent } from './page-admin/menu/menu-list/menu-list.component';
import { MenuDetailComponent } from './page-admin/menu/menu-detail/menu-detail.component';
import { IndexComponent } from './page-client/index/index.component';
import { PhoneComponent } from './page-client/phone/phone.component';
import { CartComponent } from './page-client/cart/cart.component';
import { PayComponent } from './page-client/pay/pay.component';
import { RegisterComponent } from './register/register.component';
import { QuizPmComponent } from './quizPm/quiz-pm/quiz-pm.component';




@NgModule({
  declarations: [
    WelcomeAdminComponent,
    AuthUserListComponent,
    BillListComponent,
    CartListComponent,
    MetadataTypeListComponent,
    MetadataValueListComponent,
    ProductListComponent,
    PromotionListComponent,
    AuthUserDetailComponent,
    BillDetailComponent,
    CartDetailComponent,
    MetadataTypeDetailComponent,
    MetadataValueDetailComponent,
    ProductDetailComponent,
    PromotionDetailComponent,
    LoginComponent,
    MenuListComponent,
    MenuDetailComponent,
    IndexComponent,
    PhoneComponent,
    CartComponent,
    PayComponent,
    BillListComponent,
    RegisterComponent,
    QuizPmComponent
  ],
  imports: [
    BrowserModule,
    NgZorroAntdModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    RouterModule,
      ReactiveFormsModule,
      
  ],
  entryComponents: [
    AuthUserDetailComponent,
    BillDetailComponent,
    MenuDetailComponent,
    CartDetailComponent,
    MetadataTypeDetailComponent,
    MetadataValueDetailComponent,
    ProductDetailComponent,
    PromotionDetailComponent,
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true},
    { provide: NZ_I18N, useValue: en_US }
  ]
})
export class PagesModule { }
