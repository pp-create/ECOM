import { Injectable } from '@angular/core';
import { Iproduct } from '../shared/models/Iproduct';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

import { ICategroy } from '../shared/models/icategroy';
import { Pagination } from '../shared/models/Pagination';
import { ProductParam } from '../shared/models/product-param';


@Injectable({
  providedIn: 'root'
})

export class ShopService  {
  constructor(private http: HttpClient) {}

  baseURL = 'https://localhost:7028/api';
  

  getProduct(om:ProductParam): Observable<Pagination> {
    let params = new HttpParams();
    if (om.CategoryId) {
      params = params.append("CategoryId", om.CategoryId);
    }if (om.SortSelected) {
      params = params.append("Sort", om.SortSelected);
    }if (om.Search) {
      params = params.append("Search", om.Search);
    }
    params = params.append("pageNumber", om.pageNumber);
       params = params.append("pageSize", om.pageSize);
    return this.http.get<Pagination>(
      this.baseURL + "/Products/GetAllProducts",
      { params } // <-- هنا تضيف الباراميتر للطلب
    );
  }
  
  
  getCategroy(): Observable<ICategroy[]> {
    return this.http.get<ICategroy[]>(this.baseURL + "/Categories/Get_all");
  }
  
}



