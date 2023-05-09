import { SweetAlertService } from './../sweet-alert.service';
import { Observable , Subscriber} from 'rxjs';
import { TicketService } from './../ticket.service';
import { Component } from '@angular/core';
import { Ticket } from '../ticket';
import { FormBuilder,FormGroup,Validators } from '@angular/forms';

@Component({
  selector: 'app-ticket',
  templateUrl: './ticket.component.html',
  styleUrls: ['./ticket.component.scss']
})
export class TicketComponent {
  
  TicketList:Ticket[]=[];
  NewTicket:Ticket=new Ticket();
  EditTicekt:Ticket=new Ticket();
  //Image
  picture!: Observable<any>;
  base64code!: any
  onChange = ($event: Event) => {
    const target = $event.target as HTMLInputElement;
    const file: File = (target.files as FileList)[0];
    console.log(file);
    this.convertToBase64(file)
    
  };
  convertToBase64(file: File){

    const observable = new Observable((subscriber: Subscriber<any>) => {
      this.readFile(file, subscriber);
    });
    
    observable.subscribe((d) => {
      console.log(d)
      this.picture = d
      
      this.base64code = d
     this.NewTicket.image=d
     this.EditTicekt.image=d
    })
  }
  readFile(file: File, subscriber: Subscriber<any>) {

    const filereader = new FileReader();
    filereader.readAsDataURL(file);
    filereader.onload = () => {
      subscriber.next(filereader.result);
      subscriber.complete();
    };
    filereader.onerror = (error) => {
      subscriber.error(error);
      subscriber.complete();
    };
  }


  
  

  
  constructor(private TicketService:TicketService){
    // this.from=this.formBuilder.group(
    //   {
    //     name:['',
    //     [
    //       Validators.required,
    //       Validators.pattern('^[a-zA-Z \-\']+'),
    //       Validators.maxLength(20)
    //     ]
    //   ],
    //   count:['',Validators.required],
    //   }
    // )
  }
  ngOnInit()
  {
    this.Getall();
  }
  Getall()
  {
    this.TicketService.GetAllTickets().subscribe(
      (Response)=>{
        this.TicketList=Response;
        // console.log(this.EmployeeList);
      },
      (Error)=>{
        console.log(Error);
      }
    );
  }
  SaveClick()
  {

    // if(this.from.invalid){
    //   this.submitted=true
    //   return;
    // }
    
    this.TicketService.SaveTickets(this.NewTicket).subscribe(
      (response)=>{
this.Getall();
this.NewTicket.name="";
this.NewTicket.count="";
this.NewTicket.image="";
      }
    )
  }
  EditClick(Ticket:Ticket)
  {
    
  //  alert(emp.name)
  this.EditTicekt=Ticket;
  }
  UpdateClick()
  {
    // if(this.from.invalid){
    //   this.submitted=true
    //   return;
    // }
   // alert(this.EditEmployee.name)
   this.TicketService.UpdateTickets(this.EditTicekt).subscribe(
    (response)=>{
      this.Getall();
    },
    (error)=>{
      console.log(error);
    }
   );
  
  }
  DeleteClick(id:number)
  {
    
    // alert(id);
     let ans=window.confirm('Do you want to delete data !!');
     if(!ans) return;

    this.TicketService.DeleteTicket(id).subscribe(
      (response)=>{
        this.Getall();
      },
      (error)=>{
       // console.log(error);
      },
    );
      
   
  }
  
      

}


