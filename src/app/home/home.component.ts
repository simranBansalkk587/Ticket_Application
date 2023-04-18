import { Ticket } from '../ticket';
import { TicketService } from './../ticket.service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {

  TicketList:Ticket[]=[];

  constructor(private TicketService:TicketService){}
  ngOnInit()
  {
    this.Getall();
  }
  Getall()
  {
    this.TicketService.GetAllTickets().subscribe(
      (Response)=>{
        this.TicketList=Response;
        // console.log(this.EmployeeList);
      },
      (Error)=>{
        console.log(Error);
      }
    );
  }
}
