import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Leave } from 'src/app/models/leave';
import { LeaveService } from 'src/app/services/leave.service';

@Component({
  selector: 'app-add-leaveRequest',
  templateUrl: './add-leaveRequest.component.html',
  styleUrls: ['./add-leaveRequest.component.css']
})
export class AddLeaveRequestComponent implements OnInit {
  addLeaveRequest:Leave={
    id: 0,
    startDate:'',
    endDate:'',
    type:''

  };

  constructor(private leaveService:LeaveService,private router:Router) { }

  ngOnInit() {
  }
  addLeave(){
    this.leaveService.addLeave(this.addLeaveRequest).subscribe({
      next:(leave)=>{
        this.router.navigate(['leaveRequest']);
      }
    });
  }

}
