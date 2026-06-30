import { Component, computed, signal } from '@angular/core';
import { NatwestProductsService } from '../services/natwest-products.service';
import { BankProduct } from '../api/bank-product';

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [],
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent {
  readonly isLoading = signal(true);
  readonly error = signal<string | null>(null);
  readonly products = signal<BankProduct[]>([]);
  readonly hasProducts = computed(() => this.products().length > 0);
  readonly emptyState = computed(() => !this.isLoading() && !this.products().length && !this.error());

  constructor(private readonly natwestProductsService: NatwestProductsService) {
    this.loadProducts();
  }

  loadProducts(): void {
    this.isLoading.set(true);
    this.error.set(null);

    this.natwestProductsService.getProducts().subscribe({
      next: (items) => this.products.set(items),
      error: () => this.error.set('Unable to load NatWest products.'),
      complete: () => this.isLoading.set(false)
    });
  }
}
