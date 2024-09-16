import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListMarketComponent } from './list-market.component';

describe('ListMarketComponent', () => {
  let component: ListMarketComponent;
  let fixture: ComponentFixture<ListMarketComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ListMarketComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ListMarketComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
