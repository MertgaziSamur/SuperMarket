import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Update_Product } from '../../../../contracts/products/update_product';
import { ProductService } from '../../../../services/common/models/product.service';
import { List_Rayon } from '../../../../contracts/rayons/list-rayon';

@Component({
  selector: 'app-create-product',
  templateUrl: './create-product.component.html',
  styleUrl: './create-product.component.scss'
})
export class CreateProductComponent {
  @Input() isEditMode: boolean = false;
  @Input() updatedProduct: Update_Product | any = {};

  product: any = {};
  @Output() onSave = new EventEmitter<void>();

  constructor(private productService: ProductService) { }

  open(rayon?: List_Rayon, product?: Update_Product) {
    if (product) {
      this.product = { ...product };
      this.isEditMode = true;
    } else {
      this.product = { id: 0, name: '', rayonId: rayon ? rayon.id : 0, marketId: rayon ? rayon.marketId : 0 }; 
      this.isEditMode = false;
    }

    const modalElement = document.getElementById('createProductModal');
    if (modalElement) {
      const modal = new (window as any).bootstrap.Modal(modalElement);
      modal.show();
    }
  }

  onSubmit() {
    if (this.isEditMode) {
      this.productService.updateProduct(this.product.id, this.updatedProduct,
        () => {
          console.log('Ürün başarıyla güncellendi.');
          this.close();
          this.onSave.emit();
        },
        (errorMessage: string) => {
          console.error('Hata:', errorMessage);
        }
      );
    } else {
      this.productService.createProduct(this.product,
        () => {
          console.log('Ürün başarıyla eklendi.');
          this.close();
          this.onSave.emit();
        },
        (errorMessage: string) => {
          console.error('Hata:', errorMessage);
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
}
