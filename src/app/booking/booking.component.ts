import { Component } from '@angular/core';
import { Booking } from '../booking';
import { BookingService } from '../booking.service';

@Component({
  selector: 'app-booking',
  templateUrl: './booking.component.html',
  styleUrls: ['./booking.component.scss']
})
export class BookingComponent {
  BookingList:Booking[]=[];
  NewBooking:Booking=new Booking();
  EditBooking:Booking=new Booking();

  constructor(private BookingService:BookingService){}
  ngOnInit()
  {
    this.Getall();
  }
  Getall()
  {
    this.BookingService.getAllBooking().subscribe(
      (Response)=>{
        this.BookingList=Response;
        // console.log(this.EmployeeList);
      },
      (Error)=>{
        console.log(Error);
      }
    );
  }
  SaveClick()
  {
    this.BookingService.saveBooking(this.NewBooking).subscribe(
      (response)=>{
this.Getall();
this.NewBooking.id=0;
this.NewBooking.userId=0;
this.NewBooking.user.name="";
this.NewBooking.ticketId=0;
this.NewBooking.ticket.name="";
      }
    )
  }
  bookingticket(book:Booking)
  {
    this.NewBooking=book;
  }
}
