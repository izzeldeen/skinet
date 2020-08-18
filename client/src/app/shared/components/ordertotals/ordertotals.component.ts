import { Component, OnInit } from '@angular/core';
import { BasketService } from 'src/app/basket/basket.service';
import { Observable } from 'rxjs';
import { IBasketTotals } from '../../models/basket';

@Component({
  selector: 'app-ordertotals',
  templateUrl: './ordertotals.component.html',
  styleUrls: ['./ordertotals.component.scss']
})
export class OrdertotalsComponent implements OnInit {
basketTotal$: Observable<IBasketTotals>;
  constructor(private basketService: BasketService) { }

  ngOnInit(): void {
    this.basketTotal$ = this.basketService.basketTotal$;
  }

}
