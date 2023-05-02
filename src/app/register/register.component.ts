import { Component } from '@angular/core';
import { Register } from '../register';
import { RegisterService } from '../register.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
  registerErrorMsg:string="";
  newregister:Register= new Register();
  constructor(private registerService:RegisterService){} 
  registerclick()
  {
    this.registerService.Register(this.newregister).subscribe(
      (Response)=>{
        this.newregister.name="";
        this.newregister.address="";
        this.newregister.email="";
        this.newregister.password="";
   
      },
      (Error)=>{
        console.log(Error);
        // this.registerErrorMsg= "The password do not match."
      }
    );
  }
}
