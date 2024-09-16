import { Component, OnInit } from '@angular/core';
import { Get_Exchange } from '../../../../contracts/get-exchange';
import { ExchangeService } from '../../../../services/common/exchange.service';
import { SearchService } from '../../../../services/search-service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent implements OnInit {
  exchangeRate: Get_Exchange | null = null;
  searchTerm: string = '';
  constructor(private exchangeService: ExchangeService, private searchService: SearchService) { }

    ngOnInit(): void {
      this.getExchangeRate(); 
    }

  getExchangeRate(): void {
    this.exchangeService.getExchange(
      () => {
        console.log('Exchange data fetched successfully');
      },
      (errorMessage) => {
        console.error('Error fetching exchange data:', errorMessage);
      }
    ).then(data => {
      this.exchangeRate = data;  
    });
  }

  onSearch() {
    console.log(this.searchTerm); 
    this.searchService.updateSearchTerm(this.searchTerm); 
  }
}
