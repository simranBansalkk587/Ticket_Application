import { Injectable } from '@angular/core';
import { Ticket } from './ticket';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  cartItem:Ticket[]=[];

  constructor() { }
  addToCart(item:Ticket){
    this.cartItem.push(item);
  }
  getCart(){
    return this.cartItem;
  }
}
