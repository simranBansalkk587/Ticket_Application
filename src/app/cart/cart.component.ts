import { Subscriber } from 'rxjs';
import { BookingService } from './../booking.service';
import { CartService } from './../cart.service';
import { Booking } from './../booking';
import { TicketService } from './../ticket.service';
import { Ticket } from './../ticket';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent  {
  // cartItems: any[] = [];
  // cart!: Cart;
  // TicketList:Ticket[]=[];
ticket:Ticket[]=[];
booking:Booking=new Booking()
Ticket:Ticket=new Ticket();
//NewBooking:Booking=new Booking();

empid:any;
  constructor(private TicketService:TicketService,private CartService:CartService,private BookingService:BookingService,private router:Router){}
  ngOnInit():void{
this.ticket=this.CartService.getCart()
console.log(this.ticket);
  }
Delete(id:number)
{
  this.empid=id;
  const index=this.ticket
  .findIndex(item=>item.id===this.empid);
  if(index !==-1){
    this.ticket.splice(index,1);
  }
}
bookingticket(id:number)
{
  this.booking.ticketId=id;
  const user=sessionStorage.getItem("id")as string;
  const users=JSON.parse(user)
  this.booking.userId=users;
  this.saveBooking(this.booking)
}
saveBooking(Booking:Booking)
{
  this.BookingService.saveBooking(Booking).subscribe(
    (response)=>{
      alert("Booking Successfully")
      this.router.navigateByUrl("/home")
    }
  )
}
onSubmit(id:number) {
    
  this.booking.ticketId=id;
  const userid = sessionStorage.getItem('userId')as string;
if (userid) {
const users = JSON.parse(userid);
this.booking.userId = users;
  this.BookingService.saveBooking(this.booking).subscribe(
    (response)=>{
alert("Booking Successfuly");
    },
    (error)=>{
    console.log(error);
    alert("Not Enough tickets available")
    }
    
  )
   
  }
  
}
   
  }
  // // Getall()
  // // {
  // //   this.TicketService.GetAllTickets().subscribe(
  // //     (Response)=>{
  // //       this.TicketList=Response;
  // //       // console.log(this.EmployeeList);
  // //     },
  // //     (Error)=>{
  // //       console.log(Error);
  // //     }
  // //   );
  // // }
  
 
   
  // bookcart()
  // {
  //   this.CartItem
  // }

  // ngOnInit(): void {
  //   this.cartService.getCartSubject().subscribe(cartItems => {
  //     this.cartItems = cartItems;
  //   });
  // }

  // removeFromCart(item: any): void {
  //   this.cartService.removeFromCart(item);
  // }

  // clearCart(): void {
  //   this.cartService.clearCart();
  // }
  // items: Ticket[] = [];

  // // constructor(private CartService:CartService){}
  // ngOnInit()
  // {
  //   this.Getall();
  // }
  // ngOnInit(): void {
    // this.items = this.CartService.getItems();}
  // Getall()
  // {
  //   this.TicketService.GetAllTickets().subscribe(
  //     (Response)=>{
  //       this.Ticket=Response;
  //       // console.log(this.EmployeeList);
  //     },
  //     (Error)=>{
  //       console.log(Error);
  //     }
  // removeItem(index: number) {
  //   // this.cartService.removeFromCart(index);
  //   this.items = this.CartService.getItems();
  //   // this.totalCost = this.cartService.getTotalCost();
  // // }
    
  



