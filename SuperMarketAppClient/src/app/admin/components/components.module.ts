import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductsModule } from './products/products.module';
import { MarketsModule } from './markets/markets.module';
import { RayonsModule } from './rayons/rayons.module';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    ProductsModule,
    MarketsModule,
    RayonsModule,
    FormsModule
  ]
})
export class ComponentsModule { }
