import { Component } from '@angular/core';
import { Register } from '../register';
import { RegisterService } from '../register.service';
import { FormGroup,FormControl,Validators } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
loginForm=new FormGroup({
  name:new FormControl('',[Validators.required]),
  email:new FormControl('',[Validators.required,Validators.email]),
  address:new FormControl('',[Validators.required,Validators.minLength(3)]),

})


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
        //this.newregister.password="";
   
      },
      (Error)=>{
        console.log(Error);
        // this.registerErrorMsg= "The password do not match."
      }
    );
  }
  loginUser()
  {
    console.warn(this.loginForm.value);
  }
  get name()
  {
    return this.loginForm.get('name');
  }
  get email()
  {
    return this.loginForm.get('email');
  }
  get address()
  {
    return this.loginForm.get('address');
  }
}
