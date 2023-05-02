import { MailService } from '@sendgrid/mail';
import { RoleguradService } from './rolegurad.service';
import { LoginService } from './login.service';
import { Component, NgModule } from '@angular/core';
import { ActivatedRouteSnapshot, RouterModule } from '@angular/router';
import { Role } from './role';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
  
})

export class AppComponent {
  title = 'Ticket_booking_Angular';
  roles:Role=new Role()

  constructor(public loginService:LoginService,public RoleguradService:RoleguradService){}
  logoutClick()
{
  this.loginService.logout();
}
checkRole()
{
  this.RoleguradService.canActivate
    
 }
//  sendEmail() {
//   const email = {
//     to: 'user@example.com',
//     subject: 'Reset Password',
//     html: '<p>Click <a href="http://localhost:4200/reset-password">here</a> to reset your password.</p>'
//   };

//   this.mailService.sendEmail(email.to, email.subject, email.html).then((result) => {
//     console.log('Email sent successfully');
//   }).catch((error) => {
//     console.log(error);
//   });
// }

}
