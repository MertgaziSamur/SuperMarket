import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MarketsComponent } from './markets.component';
import { RouterModule } from '@angular/router';
import { ListMarketComponent } from './list-market/list-market.component';
import { CreateMarketComponent } from './create-market/create-market.component';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    MarketsComponent,
    ListMarketComponent,
    CreateMarketComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild([
      { path: "", component: MarketsComponent }
    ])
  ]
})
export class MarketsModule { }
