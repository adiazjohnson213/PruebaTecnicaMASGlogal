import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { HttpService } from 'src/app/core/services/http.service';
import { environment } from 'src/environments/environment';
import { Employee } from '../model/employee';

@Injectable({
  providedIn: 'root'
})
export class EmpoyeesService extends HttpService {

  constructor(protected http: HttpClient) {  super(http); }

  public getEmployeeById(employeeId: number) {
    const endPoint = `${environment.serverUrl}/Employee/${employeeId}`;
    return this.doGet<Employee>(endPoint, this.optsName('Get Employee By Id'));
  }

  public getEmployees() {
    const endPoint = `${environment.serverUrl}/Employee`;
    return this.doGet<Array<Employee>>(endPoint, this.optsName('Get All Employees'));
  }

}
