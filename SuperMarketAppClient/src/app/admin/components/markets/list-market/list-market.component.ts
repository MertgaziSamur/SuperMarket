import { Component, OnInit, ViewChild } from '@angular/core';
import { List_Market } from '../../../../contracts/markets/list-market';
import { CreateMarketComponent } from '../create-market/create-market.component';
import { MarketsService } from '../../../../services/common/models/markets.service';
import { Update_Market } from '../../../../contracts/markets/update-market';
import { SearchService } from '../../../../services/search-service';

@Component({
  selector: 'app-list-market',
  templateUrl: './list-market.component.html',
  styleUrl: './list-market.component.scss'
})
export class ListMarketComponent implements OnInit {

  markets: List_Market[] = [];
  filteredMarkets: List_Market[] = [];

  @ViewChild('createMarketModal') createMarketModal: CreateMarketComponent;

  constructor(private marketService: MarketsService, private searchService: SearchService) { }

    ngOnInit(): void {
      this.getMarkets();

      this.searchService.currentSearchTerm.subscribe(term => {
        this.filterMarkets(term);
      });
  }

  getMarkets() {
    this.marketService.listMarket(
      () => {
        console.log("Marketler başarıyla yüklendi.");
      },
      (errorMessage: string) => {
        console.error("Marketler yüklenirken hata oluştu: ", errorMessage);
      }
    ).then(markets => {
      this.markets = markets;
      this.filteredMarkets = markets;
    });
  }

  refreshMarkets() {
    this.getMarkets();
  }

  deleteMarket(id: number) {
    if (confirm('Bu marketi silmek istediğinize emin misiniz?')) {
      this.marketService.deleteMarket(id,
        () => this.refreshMarkets(),
        (errorMessage: string) => console.error('Silme hatası:', errorMessage)
      );
    }
  }

  openCreateMarketModal(market?: List_Market) {
    if (market) {
      const updateMarket: Update_Market = {
        id: market.id,
        name: market.name,
      };
      this.createMarketModal.open(updateMarket);
    } else {
      this.createMarketModal.open();
    }
  }

  filterMarkets(term: string) {
    if (term && term.trim()) {

      this.filteredMarkets = this.markets.filter(market =>
        market.name.toLowerCase().includes(term.toLowerCase())
      );
    } else {

      this.filteredMarkets = this.markets;
    }
  }
}
