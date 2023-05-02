import { CartService } from './../cart.service';
import { BookingService } from './../booking.service';
import { Booking } from './../booking';
import { Router } from '@angular/router';
import { Ticket } from '../ticket';
import { TicketService } from './../ticket.service';
import { Component, Input } from '@angular/core';
import { tick } from '@angular/core/testing';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {

  TicketList:Ticket[]=[];
  NewBooking:Booking=new Booking();
  @Input() product: any;
  Ticket:Ticket=new Ticket();
  ticketdata:undefined |Ticket;
  bookingData:undefined |Booking;
  bookingCount:number=1;
  constructor(private TicketService:TicketService,private router:Router ,private BookingService:BookingService,private CartService:CartService){}
  ngOnInit()
  {
    this.Getall();
  }
  Getall()
  {
    this.TicketService.GetAllTickets().subscribe(
      (Response)=>{
        this.TicketList=Response;
       // this.router.navigateByUrl("/employee");  
              // console.log(this.EmployeeList);
      },
      (Error
        )=>{
        console.log(Error);
      }
    );
  }
  
bookingticket(Ticket:Ticket)
  {
  this.Ticket=Ticket;
  this.CartService.addToCart(this.Ticket);
  this.router.navigateByUrl("/cart")

}
AddTocart()
{
  if(this.bookingData){
    this.bookingData.count=this.bookingCount;
    console.warn(this.bookingData);

  }
}
}
