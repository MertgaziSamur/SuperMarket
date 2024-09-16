import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ProductService } from '../../../../services/common/models/product.service';
import { Update_Product } from '../../../../contracts/products/update_product';
import { Create_Product } from '../../../../contracts/products/create_product';
import { List_Market } from '../../../../contracts/markets/list-market';
import { MarketsService } from '../../../../services/common/models/markets.service';
import { List_Rayon } from '../../../../contracts/rayons/list-rayon';

@Component({
  selector: 'app-create-product',
  templateUrl: './create-product.component.html',
  styleUrl: './create-product.component.scss'
})
export class CreateProductComponent implements OnInit {
  @Input() isEditMode: boolean = false;
  markets: List_Market[] = [];
  rayons: List_Rayon[] = [];
  selectedMarketId: number = 0;
  @Input() set productData(product: Update_Product | null) {
    if (product) {
      this.isEditMode = true;
      this.product = { ...product };
    } else {
      this.isEditMode = false;
      this.product = { id: 0, name: '', rayonId: 0, marketId: 0, createdDate: new Date(), updatedDate: new Date() };
    }
  }

  product: Update_Product = {
    id: 0,
    name: '',
    rayonId: 0,
    marketId: 0,
    updatedDate: new Date()
  };

  @Output() onSave = new EventEmitter<void>();

  constructor(private marketService: MarketsService, private productService: ProductService) { }
    ngOnInit(): void {
      this.getMarkets();
    }

  open(product?: Update_Product) {
    this.productData = product || null;

    if (!product) {
      this.product = { id: 0, name: '', rayonId: 0, marketId: 0 };
    }

    const modalElement = document.getElementById('createProductModal');
    if (modalElement) {
      const modal = new (window as any).bootstrap.Modal(modalElement);
      modal.show();
    }
  }

  onSubmit() {
    if (this.isEditMode) {
      this.productService.updateProduct(this.product as Update_Product, this.product.id,
        () => {
          console.log('Ürün başarıyla güncellendi.');
          this.close();
          this.onSave.emit();
        },
        (errorMessage: string) => {
          console.error('Güncelleme hatası:', errorMessage);
        }
      );
    } else {
      const newProduct: Create_Product = {
        name: this.product.name,
        marketId: this.selectedMarketId,
        rayonId: this.product.rayonId
      };

      this.productService.createProduct(newProduct,
        () => {
          console.log('Ürün başarıyla eklendi.');
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
    const modalElement = document.getElementById('createProductModal');
    if (modalElement) {
      const modal = (window as any).bootstrap.Modal.getInstance(modalElement);
      if (modal) {
        modal.hide();
      }
    }
  }

  deleteProduct() {
    if (confirm('Bu ürünü silmek istediğinizden emin misiniz?')) {
      this.productService.deleteProduct(this.product.id,
        () => {
          this.close();
          window.location.reload();
        },
        (errorMessage: string) => console.error('Silme hatası:', errorMessage)
      );
    }
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
    });
  }

  onMarketChange() {
    if (this.selectedMarketId) {
      this.marketService.getMarketRayons(this.selectedMarketId).then(rayons => {
        this.rayons = rayons;
      }).catch(error => {
        console.error('Reyonlar yüklenirken hata oluştu:', error);
      });
    }
  }

}
