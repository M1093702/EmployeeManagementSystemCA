import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Designation } from 'src/app/models/designation';
import { DesignationService } from 'src/app/services/designation.service';

@Component({
  selector: 'app-add-designation',
  templateUrl: './add-designation.component.html',
  styleUrls: ['./add-designation.component.css']
})
export class AddDesignationComponent implements OnInit {

  addDesignationRequest:Designation={
    id: 0,
    designationName:'',
    department:'',

  };

  constructor(private designationService:DesignationService,private router:Router) { }

  ngOnInit() {
  }

  addDesignation(){
    this.designationService.addDesignation(this.addDesignationRequest).subscribe({
      next:(designation)=>{
        this.router.navigate(['designation']);
      }
    });
  }

}
