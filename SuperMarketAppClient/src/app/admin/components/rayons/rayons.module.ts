import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RayonsComponent } from './rayons.component';
import { RouterModule } from '@angular/router';
import { ListRayonComponent } from './list-rayon/list-rayon.component';
import { CreateRayonComponent } from './create-rayon/create-rayon.component';
import { FormsModule } from '@angular/forms';
import { CreateProductComponent } from './create-product/create-product.component';



@NgModule({
  declarations: [
    RayonsComponent,
    ListRayonComponent,
    CreateRayonComponent,
    CreateProductComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild([
      { path: "", component: RayonsComponent }
    ])
  ]
})
export class RayonsModule { }
