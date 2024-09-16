import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateRayonComponent } from './create-rayon.component';

describe('CreateRayonComponent', () => {
  let component: CreateRayonComponent;
  let fixture: ComponentFixture<CreateRayonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CreateRayonComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CreateRayonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
