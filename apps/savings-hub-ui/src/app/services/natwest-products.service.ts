import { HttpClient } from '@angular/common/http';
import { Injectable, InjectionToken, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { BankProduct } from '../api/bank-product';

export const BACKEND_API_URL = new InjectionToken<string>('BACKEND_API_URL');

@Injectable({
  providedIn: 'root'
})
export class NatwestProductsService {
  private readonly http = inject(HttpClient);
  private readonly apiBaseUrl = inject(BACKEND_API_URL, { optional: true }) ?? new URL('/api', location.origin).toString();
  private readonly productsRoute = new URL('natwest/personal-current-accounts', this.apiBaseUrl).toString();

  getProducts(): Observable<BankProduct[]> {
    return this.http.get<BankProduct[]>(this.productsRoute);
  }
}
