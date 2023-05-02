import { Register } from './../register';
import { Component } from '@angular/core';
import { RegisterService } from '../register.service';

@Component({
  selector: 'app-password',
  templateUrl: './password.component.html',
  styleUrls: ['./password.component.scss']
})
export class PasswordComponent {
  newregister:Register= new Register();
  id:any
constructor(private registerService:RegisterService){}
// registerclick()
// {
//   this.registerService.Register(this.newregister).subscribe(
//     (Response)=>{
//       this.newregister.password="";
//     },
//     (Error)=>{
//       console.log(Error);
//       // this.registerErrorMsg= "The password do not match."
//     }
//     );
Register()
{


}


}

