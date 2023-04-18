import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Register } from './register';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  constructor(private httpclient:HttpClient) { }
  Register(newregister:Register):Observable<Register>
  {
    return this.httpclient.post<Register>("https://localhost:44372/api/Register/User",newregister)
  }}
