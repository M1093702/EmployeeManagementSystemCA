import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EmployeesListComponent } from './components/employees/employees-list/employees-list.component';
import { AddEmployeeComponent } from './components/employees/add-employee/add-employee.component';
import { EditEmployeeComponent } from './components/employees/edit-employee/edit-employee.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UserLoginComponent } from './user/user-login/user-login.component';
import { UserRegisterComponent } from './user/user-register/user-register.component';

import { AlertifyService } from './services/alertify.service';
import { AuthService } from './services/auth.service';
import { NavbarComponent } from './navbar/navbar.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { UserServiceService } from './services/userService.service';

import { DayPilotModule } from 'daypilot-pro-angular';
import { DesignationComponent } from './designation/designation.component';
import { AddDesignationComponent } from './designation/add-designation/add-designation.component';
import { EditDesignationComponent } from './designation/edit-designation/edit-designation.component';
import { LeaveRequestComponent } from './leaveRequest/leaveRequest.component';
import { AddLeaveRequestComponent } from './leaveRequest/add-leaveRequest/add-leaveRequest.component';
import { EditLeaveRequestComponent } from './leaveRequest/edit-leaveRequest/edit-leaveRequest.component';
import { FilterPipe } from './pipe/filter.pipe';
import { SortPipe } from './pipe/sort.pipe';



@NgModule({
  declarations: [
    AppComponent,
    EmployeesListComponent,
    AddEmployeeComponent,
    EditEmployeeComponent,
    UserLoginComponent,
    UserRegisterComponent,
    NavbarComponent,
    DesignationComponent,
    AddDesignationComponent,
    EditDesignationComponent,
    LeaveRequestComponent,
    AddLeaveRequestComponent,
    EditLeaveRequestComponent,
    FilterPipe,
    SortPipe

   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    BsDropdownModule.forRoot(),
    DayPilotModule

  ],
  providers: [

    AlertifyService,
    AuthService,
    UserServiceService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
