import { Component, OnInit } from '@angular/core';
import { Login } from '../login';
import { LoginService } from '../login.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent  {
  login:Login=new Login();
  loginErrorMsg:string="";

  

  constructor(private loginService:LoginService,private router:Router ){}
  




  loginClick()
  {
    
    //alert(this.login.username)//testing
    this.loginService.CheckUser(this.login).subscribe(
      (response)=>{
        
        this.router.navigateByUrl("/home");
      },
      (error)=>{
        console.log(error);
       //alert('Wrong User Password');
      this.loginErrorMsg="Wrong User Message";
      }
    );
  }
}


