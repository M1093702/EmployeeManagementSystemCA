import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddEmployeeComponent } from './components/employees/add-employee/add-employee.component';
import { EditEmployeeComponent } from './components/employees/edit-employee/edit-employee.component';
import { EmployeesListComponent } from './components/employees/employees-list/employees-list.component';
import { AddDesignationComponent } from './designation/add-designation/add-designation.component';
import { DesignationComponent } from './designation/designation.component';
import { EditDesignationComponent } from './designation/edit-designation/edit-designation.component';

import { AddLeaveRequestComponent } from './leaveRequest/add-leaveRequest/add-leaveRequest.component';
import { EditLeaveRequestComponent } from './leaveRequest/edit-leaveRequest/edit-leaveRequest.component';
import { LeaveRequestComponent } from './leaveRequest/leaveRequest.component';

import { UserLoginComponent } from './user/user-login/user-login.component';
import { UserRegisterComponent } from './user/user-register/user-register.component';

const routes: Routes = [


  {
    path:'employees',
    component:EmployeesListComponent
  },
  {
    path:'employees/add',
    component:AddEmployeeComponent
  },
  {
    path:'employees/edit/:id',
    component:EditEmployeeComponent
  },
  {
    path:'designation',
    component:DesignationComponent
  },
  {
    path:'designation/add',
    component:AddDesignationComponent
  },
  {
    path:'designation/edit/:id',
    component:EditDesignationComponent
  },
  {
    path:'leaveRequest',
    component:LeaveRequestComponent
  },
  {
    path:'leaveRequest/add',
    component:AddLeaveRequestComponent
  },
  {
    path:'leaveRequest/edit/:id',
    component:EditLeaveRequestComponent
  },
  {
    path:'user/login',
    component:UserLoginComponent
  },
  {
    path:'user/register',
    component:UserRegisterComponent
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
