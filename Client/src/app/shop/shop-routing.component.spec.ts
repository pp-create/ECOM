import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShopRoutingComponent } from './shop-routing.component';

describe('ShopRoutingComponent', () => {
  let component: ShopRoutingComponent;
  let fixture: ComponentFixture<ShopRoutingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ShopRoutingComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShopRoutingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
