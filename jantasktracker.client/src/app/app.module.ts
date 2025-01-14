import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FooterComponent } from './components/footer/footer.component';
import { EmployeeSectionComponent } from './components/employee-section/employee-section.component';
import { EmployeeCreateComponent } from './components/employee-section/employee-create/employee-create.component';
import { EmployeeListComponent } from './components/employee-section/employee-list/employee-list.component';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DepartmentSectionComponent } from './components/department-section/department-section.component';
import { DepartmentCreateComponent } from './components/department-section/department-create/department-create.component';
import { DepartmentListComponent } from './components/department-section/department-list/department-list.component';
import { RoleSectionComponent } from './components/role-section/role-section.component';
import { RoleCreateComponent } from './components/role-section/role-create/role-create.component';
import { RoleListComponent } from './components/role-section/role-list/role-list.component';
import { ProjectListComponent } from './components/project-list/project-list.component';
import { ProjectComponent } from './components/project-list/project/project.component';
import { ProjectModalComponent } from './components/project-list/project-modal/project-modal.component';
import { ProjectTaskComponent } from './components/project-list/project-task/project-task.component';
import { ProjectTaskModalComponent } from './components/project-list/project-task-modal/project-task-modal.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    EmployeeSectionComponent,
    EmployeeCreateComponent,
    EmployeeListComponent,
    DepartmentSectionComponent,
    DepartmentCreateComponent,
    DepartmentListComponent,
    RoleSectionComponent,
    RoleCreateComponent,
    RoleListComponent,
    ProjectListComponent,
    ProjectComponent,
    ProjectModalComponent,
    ProjectTaskComponent,
    ProjectTaskModalComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule,
    NgbModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
