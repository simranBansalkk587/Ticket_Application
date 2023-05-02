import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { ContactComponent } from './contact/contact.component';
import { AboutComponent } from './about/about.component';
import { TicketComponent } from './ticket/ticket.component';
import { RegisterComponent } from './register/register.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BookingComponent } from './booking/booking.component';
import { LoginComponent } from './login/login.component';
import { JwtintercapterService } from './jwtintercapter.service';
import{JwtModule}from '@auth0/angular-jwt';
import { CartComponent } from './cart/cart.component';
import { FooterComponent } from './footer/footer.component';
import { PasswordComponent } from './password/password.component';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ContactComponent,
    AboutComponent,
    TicketComponent,
    RegisterComponent,
    BookingComponent,
    LoginComponent,
    CartComponent,
    FooterComponent,
    PasswordComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    JwtModule.forRoot({
      config:{
        tokenGetter:()=>{
          return sessionStorage.getItem("currentUser")? JSON.parse(sessionStorage.getItem("currentUser")as string).token:null;
        }
      }
       })
  ],
  providers: [
    {
      provide:HTTP_INTERCEPTORS,
      useClass:JwtintercapterService,
      multi:true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
