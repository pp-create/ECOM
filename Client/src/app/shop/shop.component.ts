import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ShopService } from './shop.service';
import { Iproduct } from '../shared/models/Iproduct';
import { ICategroy } from '../shared/models/icategroy';
import { CommonModule } from '@angular/common';
import { ProductParam } from '../shared/models/product-param';
import { __values } from 'tslib';


@Component({
  selector: 'app-shop',
  standalone: false,
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss'] ,
 // <-- استخدم styleUrls بدلاً من styleUrl
})

export class ShopComponent implements OnInit {
   om =new ProductParam();
   
  products: Iproduct[] = [];
  selectedSort: string ; 
  totalcount:number
  
  constructor(private productService: ShopService) {}

  ngOnInit(): void {
    this.getProducts();
    this.getCategroy();
  }

  getProducts(): void {
    this.productService.getProduct(this.om).subscribe({
      next: (data) => {
        console.log('Products:', data);
        this.products = data.data;
        this.totalcount=data.totalCount
        this.om.pageNumber=data.pageNumber
        this.om.pageSize=data.pageSize
      },
      error: (err) => {
       
      }
    });
  }
  //pangition page
  onchangepage(event:any){
    console.log('Page changed to:',event?.value ?? event?.page ?? event);
    this.om.pageNumber=event?.page 

    console.log(event?.page )
    this.getProducts()
  }
//get categroy 
Categrioes: ICategroy[] = [];
categroyid: number ;
  getCategroy(): void {
    this.productService.getCategroy().subscribe({
      next: (data) => {
        console.log('Categories:', data);
        this.Categrioes = data;
      },
      error: (err) => {
        console.error('Error fetching categories:', err);
      }
    });
  }
  Isselected(id:number){
    this.om.CategoryId = id;
    this.getProducts();
  }


  sortOptions = [
    { name: 'Name', value: 'Name' },
    { name: 'Price: min-max', value: 'PriceAsc' },
    { name: 'Price: max-min', value: 'PriceDesc' }
  ];
  sortbyprice(sort:Event){
  
this.selectedSort=(sort.target as HTMLInputElement).value

this.getProducts();
  }
  // sreach by text 
  sreach:string;
  onsreach(sreach:string){
    this.om.Search=sreach;
    this.getProducts();

  }
  @ViewChild('sreach') searchInput: ElementRef; // Reference to the search input element
@ViewChild('SortSelected') selected: ElementRef;
  ResetValue() {
    this.om.Search= ''; 
    this.om.SortSelected = this.sortOptions[0].value;
    this.om.CategoryId = 0;
  
    this.searchInput.nativeElement.value = '';
    this.selected.nativeElement.selectedIndex = 0;
  
    this.getProducts();
  }
}
