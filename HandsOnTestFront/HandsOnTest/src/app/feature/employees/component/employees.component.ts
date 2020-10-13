import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Employee } from '../model/employee';
import { EmpoyeesService } from '../services/empoyees.service';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.sass']
})
export class EmployeesComponent implements OnInit {

  columns: string[] = ['ID', 'Name', 'Contract Type Name', 'Role Id', 'Role Name', 'Role Description',
    'Hourly Salary', 'Monthly Salary', 'Anual Salary'];
  employeeForm: FormGroup;
  listEmployees: Array<Employee>;

  constructor(
      private fb: FormBuilder,
      private employeeService: EmpoyeesService,
      private toastr: ToastrService) { }

  ngOnInit() {
    this.employeeForm = this.fb.group({
      employeeId: []
    });
  }

  onSubmit() {
    if (this.employeeForm.value.employeeId) {
      this.employeeService.getEmployeeById(Number(this.employeeForm.value.employeeId)).subscribe(result => {
        this.listEmployees = new Array<Employee>();
        this.listEmployees.push(result);
      },
      error => {
        this.toastr.error(error.error.message);
      });
    } else {
      this.employeeService.getEmployees().subscribe(result => {
        this.listEmployees = result;
      },
      error => {
        this.toastr.error(error.error.message);
      });
    }
  }

}
