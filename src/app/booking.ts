import { AnimationKeyframesSequenceMetadata } from "@angular/animations";

export class Booking {
    id:number;
    userId:number;
    user:any;
    ticketId:number;
    ticket:any;
    count:number;
    constructor()
    {
        this.id=0;
        this.userId=0;
        this.user=null;
        this.ticketId=0;
        this.ticket=null;
        this.count=0;
        
    }
}
