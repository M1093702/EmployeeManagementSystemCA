import { HttpRequest } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Designation } from '../models/designation';
import { DesignationService } from '../services/designation.service';

@Component({
  selector: 'app-designation',
  templateUrl: './designation.component.html',
  styleUrls: ['./designation.component.css']
})
export class DesignationComponent implements OnInit {

  designations:Designation[]=[] ;

  Department='';
  SearchDepartment='';
  SortbyParam:'' |any;
  SortDirection:'asc'|any ;

  constructor(private designationService:DesignationService) { }

  DesignationIdFilter:string="";
  DesignationNameFilter:string="";
  DesignationListWithoutFilter:string="";


  ngOnInit(): void {
    this.designationService.getAllDeignations().subscribe({
      next:(designations)=>{
       this.designations=designations;
      },error:(response)=>{
        console.log(response);
      }
    });
 }

 onDepartmentFilter(){
  this.SearchDepartment=this.Department;
 }

 onDepartmentFilterClear(){
  this.SearchDepartment='';
  this.Department='';
 }

 onSortDirection(){
  if(this.SortDirection==='desc'){
    this.SortDirection='asc';
  }
  else{
    this.SortDirection='desc';
  }
 }



}


