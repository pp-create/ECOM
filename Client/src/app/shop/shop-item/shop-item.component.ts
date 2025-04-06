import { Component, Input, input } from '@angular/core';
import { Iproduct } from '../../shared/models/Iproduct';

@Component({
  selector: 'app-shop-item',
  standalone: false,
  templateUrl: './shop-item.component.html',
  styleUrl: './shop-item.component.scss'
})
export class ShopItemComponent {
  @Input() product: Iproduct;
}
