import { Injectable } from '@angular/core';
import { Role } from './role';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { JwtactiateguradService } from './jwtactivategurad.service';

@Injectable({
  providedIn: 'root'
})
export class RoleguradService {
 roles:Role=new Role()
  constructor( private router:Router,private Jwthelper:JwtactiateguradService) { }
  canActivate(route:ActivatedRouteSnapshot,state:RouterStateSnapshot):boolean{
    debugger;
    const user=sessionStorage.getItem('role')as string;
    const users=JSON.parse(user)
    this.roles.role=users;
    const isAutherzied=this.roles.role===(route.data["role"]);
    if(!isAutherzied)
    {
      alert("Only Admin Can Access this Page");
      return false;
    }
    return true;
  }
  checkRole()
  {
    //  this.("Admin");
   }
  }

