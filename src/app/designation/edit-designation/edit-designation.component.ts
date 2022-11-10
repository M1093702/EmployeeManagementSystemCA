import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Route, Router, RouterModule } from '@angular/router';
import { Designation } from 'src/app/models/designation';
import { DesignationService } from 'src/app/services/designation.service';

@Component({
  selector: 'app-edit-designation',
  templateUrl: './edit-designation.component.html',
  styleUrls: ['./edit-designation.component.css']
})
export class EditDesignationComponent implements OnInit {

  designationDetails:Designation={
    id:'',
    designationName:'',
    department:''

  }

  constructor(private designationService:DesignationService,private route:ActivatedRoute,private router:Router ) { }

  ngOnInit() {
    this.route.paramMap.subscribe({
      next:(params)=>{
        const id=params.get('id');

        if(id){
          //call api
          this.designationService.getDesignation(id).subscribe({
            next:(response)=>{
                this.designationDetails=response;
            }
          })

        }
      }
    })
  }
  updateDesignation()
  {
    this.designationService.updateDesignation(this.designationDetails.id,this.designationDetails).subscribe({
      next:(response)=>{
        this.router.navigate(['designation']);
      }
    });
  }

  deleteDesignation(id:string){
    this.designationService.deleteDesignation(id).subscribe({
      next:(response)=>{
        this.router.navigate(['designation']);
      }
    })
  }

}
