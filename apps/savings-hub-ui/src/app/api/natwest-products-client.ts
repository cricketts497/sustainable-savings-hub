import { HttpClient } from '@angular/common/http';
import { Injectable, inject, InjectionToken } from '@angular/core';
import { Observable } from 'rxjs';
import { BankProduct } from './bank-product';

export const BACKEND_API_URL = new InjectionToken<string>('BACKEND_API_URL');

@Injectable({
  providedIn: 'root'
})
export class NatwestProductsClient {
  private readonly http = inject(HttpClient);
  private readonly apiBaseUrl = inject(BACKEND_API_URL, { optional: true }) ?? new URL('/api', location.origin).toString();

  getProducts(): Observable<BankProduct[]> {
    return this.http.get<BankProduct[]>(new URL('natwest/personal-current-accounts', this.apiBaseUrl).toString());
  }
}
