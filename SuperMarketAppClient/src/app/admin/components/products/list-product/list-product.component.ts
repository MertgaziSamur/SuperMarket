import { Component, OnInit, ViewChild } from '@angular/core';
import { ProductService } from '../../../../services/common/models/product.service';
import { List_Product } from '../../../../contracts/products/list_product';
import { CreateProductComponent } from '../create-product/create-product.component';
import { Update_Product } from '../../../../contracts/products/update_product';
import { SearchService } from '../../../../services/search-service';


@Component({
  selector: 'app-list-product',
  templateUrl: './list-product.component.html',
  styleUrl: './list-product.component.scss'
})
export class ListProductComponent implements OnInit {
  products: List_Product[] = [];
  selectedProduct: Update_Product | null = null;
  filteredProducts: List_Product[] = [];

  @ViewChild('createProductModal') createProductModal: CreateProductComponent;
  constructor(private productService: ProductService, private searchService: SearchService) { }

  ngOnInit(): void {
    this.getProducts();

    this.searchService.currentSearchTerm.subscribe(term => {
      this.filterProducts(term);
    });
  }

  getProducts() {
    this.productService.listProduct(
      () => {
        console.log("Ürünler başarıyla yüklendi.");
      },
      (errorMessage: string) => {
        console.error("Ürünler yüklenirken hata oluştu: ", errorMessage);
      }
    ).then(products => {
      this.products = products;
      this.filteredProducts = products;
    });
  }

  openCreateProductModal(product?: List_Product) {
    if (product) {
      const updateProduct: Update_Product = {
        id: product.id,
        name: product.name,
        rayonId: product.rayonId,
        marketId: product.marketId,
        createdDate: new Date(product.createdDate),
        updatedDate: new Date(product.updatedDate)
      };
      this.createProductModal.open(updateProduct); 
    } else {
      this.createProductModal.open(); 
    }
  }

  refreshProducts() {
    this.getProducts();
  }

  filterProducts(term: string) {
    if (term && term.trim()) {
      
      this.filteredProducts = this.products.filter(product =>
        product.name.toLowerCase().includes(term.toLowerCase()) 
      );
    } else {
      
      this.filteredProducts = this.products;
    }
  }

  deleteProduct(id: number) {
    if (confirm('Bu ürünü silmek istediğinizden emin misiniz?')) {
      this.productService.deleteProduct(id,
        () => this.refreshProducts(),
        (errorMessage: string) => console.error('Silme hatası:', errorMessage)
      );
    }
  }
}
