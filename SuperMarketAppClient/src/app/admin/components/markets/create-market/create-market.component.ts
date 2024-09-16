import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Update_Market } from '../../../../contracts/markets/update-market';
import { MarketsService } from '../../../../services/common/models/markets.service';

@Component({
  selector: 'app-create-market',
  templateUrl: './create-market.component.html',
  styleUrl: './create-market.component.scss'
})
export class CreateMarketComponent {
  @Input() isEditMode: boolean = false;
  @Input() set marketData(market: Update_Market | null) {
    if (market) {
      this.isEditMode = true;
      this.market = { ...market };
    } else {
      this.isEditMode = false;
      this.market = { id: 0, name: '' };
    }
  }

  market: Update_Market = {
    id: 0,
    name: ''
  };

  @Output() onSave = new EventEmitter<void>();

  constructor(private marketService: MarketsService) { }

  open(market?: Update_Market) {
    this.marketData = market || null;

    const modalElement = document.getElementById('createMarketModal');
    if (modalElement) {
      const modal = new (window as any).bootstrap.Modal(modalElement);
      modal.show();
    }
  }

  onSubmit() {
    if (this.isEditMode) {
      this.marketService.updateMarket(this.market, this.market.id, 
        () => {
          console.log('Pazar başarıyla güncellendi.');
          this.close();
          this.onSave.emit();
        },
        (errorMessage: string) => {
          console.error('Güncelleme hatası:', errorMessage);
        }
      );
    } else {
      this.marketService.createMarket(this.market,
        () => {
          console.log('Pazar başarıyla eklendi.');
          this.close();
          this.onSave.emit();
        },
        (errorMessage: string) => {
          console.error('Ekleme hatası:', errorMessage);
        }
      );
    }
  }

  close() {
    const modalElement = document.getElementById('createMarketModal');
    if (modalElement) {
      const modal = (window as any).bootstrap.Modal.getInstance(modalElement);
      if (modal) {
        modal.hide();
      }
    }
  }
}
