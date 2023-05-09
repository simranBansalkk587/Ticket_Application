import { ActivatedRoute, ActivatedRouteSnapshot, Router } from '@angular/router';
import { Register } from './../register';
import { Component, OnInit } from '@angular/core';
import { RegisterService } from '../register.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';


@Component({
  selector: 'app-password',
  templateUrl: './password.component.html',
  styleUrls: ['./password.component.scss']
})
export class PasswordComponent implements OnInit  {


  registerForm = new FormGroup({
    password: new FormControl('', Validators.required),
    confirmPassword: new FormControl('',[Validators.required, this.passwordMatchValidator])
  });
  
  passwordMatchValidator(control: FormControl) {
    const password = control.root.get('password');
    const confirmPassword = control.value;
    if (password && confirmPassword !== password.value) {
      return { passwordMatch: true };
    }
    return null;
  }
  
  newregister:Register= new Register();
  registerErrorMsg:string="";
  id:any;
constructor(private registerService:RegisterService,private ActivatedRoute:ActivatedRoute,private router:Router){}

ngOnInit():void{
  this.ActivatedRoute.queryParams.subscribe(
    params=>{
      this.id=params['id'];
      console.log(this.id)
      this.newregister.id=this.id
      console.log(this.newregister);
    }
  )
}
register()
{
if(this.newregister.password != this.newregister.Confirmedpassword)
{
  alert("Your PassWord doesn't match with confirm password");
}
else{

  this.registerService.SetPassWord(this.newregister).subscribe(
    (Response)=>{
    this.newregister.password="";
    this.router.navigateByUrl("/home");
    },
    (Error)=>{
      console.log(Error);
     // this.registerErrorMsg="PassWord does not Match"
    }
  )
}

}
get password()
{
  return this.registerForm.get('password');
}
get confirmPassword()
{
  return this.registerForm.get('confirmPassword');
}
loginUser()
  {
    console.warn(this.registerForm.value);
  }

}

