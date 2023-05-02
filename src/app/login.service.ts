import { Login } from './login';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  CurrentUsername:any="";
  constructor(private httpClient:HttpClient,private router:Router,private jwthelperService:JwtHelperService) { }
  CheckUser(login:Login):Observable<any>
  {
    return this.httpClient.post<any>(" https://localhost:44372/api/Register/authenticate",login).pipe(map(u=>{

    
    if(u)
    {
      this.CurrentUsername=u.username;
      sessionStorage["currentUser"]=JSON.stringify(u);//retrun username all infomation and session pass the jwt token 
      sessionStorage["userId"]=JSON.stringify(u.id);//retrun username all infomation and session pass the jwt token 
      sessionStorage["role"]=JSON.stringify(u.role);     
    }
    return u;
 
    }))
    
   
  }
  logout()//session remove the login 
  {
    this.CurrentUsername="";
    sessionStorage.removeItem("currentUser");
    this.router.navigateByUrl("/login");
  }
  public IsAuthenticated():boolean
   {
    if(this.jwthelperService.isTokenExpired())
    {
      return false;

    }
    else
    {
      return true;
    }
   }
}
