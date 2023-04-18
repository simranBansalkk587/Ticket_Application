import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Ticket } from './ticket';

@Injectable({
  providedIn: 'root'
})
export class TicketService {

  constructor(private httpclient:HttpClient) { }

  GetAllTickets():Observable<any>
  {
    return this.httpclient.get<any>("https://localhost:44372/api/Ticket")

  }
  SaveTickets(NewEmployee:Ticket):Observable<Ticket>
  { 
    return this.httpclient.post<Ticket>("https://localhost:44372/api/Ticket",NewEmployee);
  }
  UpdateTickets(EditEmployee:Ticket):Observable<Ticket>
  {
    return this.httpclient.put<Ticket>("https://localhost:44372/api/Ticket",EditEmployee);
  }
  DeleteTicket(id:number):Observable<any>
  {
    return this.httpclient.delete<any>("https://localhost:44372/api/Ticket?id="+id);
  }


}
