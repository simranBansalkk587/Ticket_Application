import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Booking } from './booking';

@Injectable({
  providedIn: 'root'
})
export class BookingService {

  constructor(private httpClient:HttpClient) { }
  getAllBooking():Observable<any>
  {
   // jwt
    // var currentuser={token:""};
    // var headers=new HttpHeaders();
    // headers=headers.set("Authorization","Bearer ");
    // var CurrentUserSession=sessionStorage.getItem("currentuser");
    // if(CurrentUserSession !=null)
    // {
    //   currentuser=JSON.parse(CurrentUserSession);
    //   headers=headers.set("Authorization","Bearer "+ currentuser.token); 

    // }
    
    return this.httpClient.get<any>("https://localhost:44372/api/Booking");
    
  
  }
  saveBooking(newBooking:Booking):Observable<Booking>
  {

    return this.httpClient.post<Booking>("https://localhost:44372/api/Booking",newBooking);
 

  }
  UpdateBooking(editBooking:Booking):Observable<Booking>
  {
    return this.httpClient.put<Booking>("https://localhost:44372/api/Booking",editBooking);
 
  }
}
