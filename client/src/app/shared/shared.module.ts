import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { PagingHeaderComponent } from './components/paging-header/paging-header.component';
import { PagerComponent } from './components/pager/pager.component';
import { CarouselModule } from 'ngx-bootstrap/carousel';
import { OrdertotalsComponent } from './components/ordertotals/ordertotals.component';



@NgModule({
  declarations: [PagingHeaderComponent, PagerComponent, OrdertotalsComponent],
  imports: [
    CommonModule,
    PaginationModule.forRoot(),
    CarouselModule.forRoot()

  ],

  exports: [PaginationModule
     , PagingHeaderComponent ,
      PagerComponent ,
      CarouselModule,
      OrdertotalsComponent
    ]
})
export class SharedModule { }
