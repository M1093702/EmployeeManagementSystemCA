import { Component, OnInit } from '@angular/core';
import { Leave } from '../models/leave';
import { LeaveService } from '../services/leave.service';

@Component({
  selector: 'app-leaveRequest',
  templateUrl: './leaveRequest.component.html',
  styleUrls: ['./leaveRequest.component.css']
})
export class LeaveRequestComponent implements OnInit {

  leaves:Leave[]=[] ;

  constructor(private leaveService:LeaveService) { }

  ngOnInit() {
    this.leaveService.getAllLeaves().subscribe({
      next:(leaves)=>{
       this.leaves=leaves;
      },error:(response)=>{
        console.log(response);
      }
    });
  }

}
