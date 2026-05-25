import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { EmployeeDto, CreateEmployeeRequest } from '../models/employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private apiUrl = 'https://localhost:7168/employees';

  constructor(private http: HttpClient) {}

  getAllEmployees(): Observable<EmployeeDto[]> {
    return this.http.get<EmployeeDto[]>(this.apiUrl);
  }

  getEmployeeById(id: number): Observable<EmployeeDto> {
    return this.http.get<EmployeeDto>(`${this.apiUrl}/${id}`);
  }

  createEmployee(employee: CreateEmployeeRequest): Observable<EmployeeDto> {
    return this.http.post<EmployeeDto>(this.apiUrl, employee);
  }

  deleteEmployee(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }

  searchEmployees(term: string): Observable<EmployeeDto[]> {
    if (!term.trim()) {
      return new Observable(observer => {
        observer.next([]);
        observer.complete();
      });
    }
    return this.http.get<EmployeeDto[]>(`${this.apiUrl}/search/${term}`);
  }
}
