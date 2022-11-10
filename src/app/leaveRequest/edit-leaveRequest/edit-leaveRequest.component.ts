import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Leave } from 'src/app/models/leave';
import { LeaveService } from 'src/app/services/leave.service';

@Component({
  selector: 'app-edit-leaveRequest',
  templateUrl: './edit-leaveRequest.component.html',
  styleUrls: ['./edit-leaveRequest.component.css']
})
export class EditLeaveRequestComponent implements OnInit {
  leaveDetails:Leave={
    id:'',
    startDate:'',
    endDate:'',
    type:''

  }

  constructor(private leaveService:LeaveService,private route:ActivatedRoute,private router:Router) { }

  ngOnInit() {
    this.route.paramMap.subscribe({
      next:(params)=>{
        const id=params.get('id');

        if(id){
          //call api
          this.leaveService.getLeave(id).subscribe({
            next:(response)=>{
                this.leaveDetails=response;
            }
          })

        }
      }
    })
  }
  updateLeave()
  {
    this.leaveService.updateLeave(this.leaveDetails.id,this.leaveDetails).subscribe({
      next:(response)=>{
        this.router.navigate(['leaveRequest']);
      }
    });
  }

  deleteLeave(id:any){
    this.leaveService.deleteLeave(id).subscribe({
      next:(response)=>{
        this.router.navigate(['leaveRequest']);
      }
    })
  }

}
