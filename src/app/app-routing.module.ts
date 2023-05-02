import { PasswordComponent } from './password/password.component';
import { FooterComponent } from './footer/footer.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { TicketComponent } from './ticket/ticket.component';
import { RegisterComponent } from './register/register.component';
import { AboutComponent } from './about/about.component';
import { ContactComponent } from './contact/contact.component';
import { BookingComponent } from './booking/booking.component';
import { LoginComponent } from './login/login.component';
import { JwtactiateguradService } from './jwtactivategurad.service';
import { RoleguradService } from './rolegurad.service';
import { CartComponent } from './cart/cart.component';

const routes: Routes = [
   {path:"home",component:HomeComponent},
{path:"ticket",component:TicketComponent,canActivate:[JwtactiateguradService,RoleguradService],data:{role:"Admin"}},
{path:"register",component:RegisterComponent},
{path:"about",component:AboutComponent,canActivate:[JwtactiateguradService]},
{path:"contact",component:ContactComponent,canActivate:[JwtactiateguradService]},
{path:"booking",component:BookingComponent,canActivate:[JwtactiateguradService,RoleguradService],data:{role:"Admin"}},
{path:"login",component:LoginComponent},
{path:"cart",component:CartComponent},
{path:"footer",component:FooterComponent},
{path:"password",component:PasswordComponent},



 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
