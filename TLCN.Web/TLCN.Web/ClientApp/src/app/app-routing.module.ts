import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { WelcomeAdminComponent } from './pages/page-admin/welcome-admin/welcome-admin/welcome-admin.component';
import { AuthUserListComponent } from './pages/page-admin/auth-users/auth-user-list/auth-user-list.component';
import { MetadataTypeListComponent } from './pages/page-admin/metadata-type/metadata-type-list/metadata-type-list.component';
import { MetadataValueListComponent } from './pages/page-admin/metadata-value/metadata-value-list/metadata-value-list.component';
import { BranchListComponent } from './pages/page-admin/branchs/branch-list/branch-list.component';
import { CartListComponent } from './pages/page-admin/carts/cart-list/cart-list.component';
import { ProductListComponent } from './pages/page-admin/products/product-list/product-list.component';
import { PromotionListComponent } from './pages/page-admin/promotions/promotion-list/promotion-list.component';
import { PagesAdminModule } from './pages/pageAdmin.module';

const routes: Routes = [
  { path: 'admin', component: WelcomeAdminComponent , children: [
    { path: 'authUser', component: AuthUserListComponent },
    { path: 'medataType', component: MetadataTypeListComponent },
    { path: 'medataValue', component: MetadataValueListComponent },
    { path: 'branch', component: BranchListComponent },
    { path: 'product', component: ProductListComponent },
    { path: 'promotion', component: PromotionListComponent },

    { path: '', pathMatch: 'full', redirectTo: '/admin' },
]},
];

@NgModule({
  imports: [
    PagesAdminModule,
    RouterModule.forRoot(routes),
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
