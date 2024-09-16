import { Component, OnInit, ViewChild } from '@angular/core';
import { List_Rayon } from '../../../../contracts/rayons/list-rayon';
import { RayonsService } from '../../../../services/common/models/rayons.service';
import { Update_Rayon } from '../../../../contracts/rayons/update-rayon';
import { CreateRayonComponent } from '../create-rayon/create-rayon.component';
import { CreateProductComponent } from '../create-product/create-product.component';
import { SearchService } from '../../../../services/search-service';

@Component({
  selector: 'app-list-rayon',
  templateUrl: './list-rayon.component.html',
  styleUrl: './list-rayon.component.scss'
})
export class ListRayonComponent implements OnInit {
  rayons: List_Rayon[] = []; 
  @ViewChild('createRayonModal') createRayonModal: CreateRayonComponent;
  @ViewChild('createProductModal') createProductModal: CreateProductComponent;
  filteredRayons: List_Rayon[] = [];
  constructor(private rayonService: RayonsService, private searchService: SearchService) { }

  ngOnInit(): void {
    this.getRayons();

    this.searchService.currentSearchTerm.subscribe(term => {
      this.filterMarkets(term);
    });
  }

  getRayons() {
    this.rayonService.listRayon(
      () => {
        console.log("Ürünler başarıyla yüklendi.");
      },
      (errorMessage: string) => {
        console.error("Ürünler yüklenirken hata oluştu: ", errorMessage);
      }
    ).then(rayons => {
      this.rayons = rayons;
      this.filteredRayons = rayons;
    });
  }

  refreshRayons() {
    this.getRayons();
  }

  deleteRayon(id: number) {
    if (confirm('Bu reyonu silmek istediğinize emin misiniz?')) {
      this.rayonService.deleteRayon(id,
        () => this.refreshRayons(),
        (errorMessage: string) => console.error('Silme hatası:', errorMessage)
      );
    }
  }

  openCreateRayonModal(rayon?: List_Rayon) {
    if (rayon) {
      const updateRayon: Update_Rayon = {
        id: rayon.id,
        rayonType: rayon.rayonType,
        marketId: rayon.marketId,
      };
      this.createRayonModal.open(updateRayon);
    } else {
      this.createRayonModal.open();
    }
  }

  openCreateProductModal(rayon: List_Rayon) {
    this.createProductModal.open(rayon);
  }

  filterMarkets(term: string) {
    if (term && term.trim()) {

      this.filteredRayons = this.rayons.filter(rayon =>
        rayon.rayonType.toLowerCase().includes(term.toLowerCase())
      );
    } else {

      this.filteredRayons = this.rayons;
    }
  }
}
