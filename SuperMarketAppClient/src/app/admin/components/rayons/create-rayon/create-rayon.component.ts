import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Update_Rayon } from '../../../../contracts/rayons/update-rayon';
import { RayonsService } from '../../../../services/common/models/rayons.service';
import { RayonType } from '../../../../contracts/rayons/create-rayon';

@Component({
  selector: 'app-create-rayon',
  templateUrl: './create-rayon.component.html',
  styleUrl: './create-rayon.component.scss'
})
export class CreateRayonComponent {
  @Input() isEditMode: boolean = false;
  @Input() set rayonData(rayon: Update_Rayon | null) {
    if (rayon) {
      this.isEditMode = true;
      this.rayon = { ...rayon };
    } else {
      this.isEditMode = false;
      this.rayon = { id: 0, marketId: 0, rayonType: RayonType.Food };
    }
  }

  rayon: Update_Rayon = {
    id: 0,
    marketId: 0,
    rayonType: RayonType.Food
  };

  @Output() onSave = new EventEmitter<void>();

  RayonType = RayonType;

  constructor(private rayonService: RayonsService) { }

  open(rayon?: Update_Rayon) {
    this.rayonData = rayon || null;

    const modalElement = document.getElementById('createRayonModal');
    if (modalElement) {
      const modal = new (window as any).bootstrap.Modal(modalElement);
      modal.show();
    }
  }

  onSubmit() {
    if (this.isEditMode) {
      this.rayonService.updateRayon(this.rayon, this.rayon.id,
        () => {
          console.log('Reyon başarıyla güncellendi.');
          this.close();
          this.onSave.emit();
        },
        (errorMessage: string) => {
          console.error('Güncelleme hatası:', errorMessage);
        }
      );
    } else {
      this.rayonService.createRayon(this.rayon,
        () => {
          console.log('Reyon başarıyla eklendi.');
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
    const modalElement = document.getElementById('createRayonModal');
    if (modalElement) {
      const modal = (window as any).bootstrap.Modal.getInstance(modalElement);
      if (modal) {
        modal.hide();
      }
    }
  }
}
