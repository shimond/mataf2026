import { Component, signal, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmployeeService } from '../services/employee.service';
import { EmployeeListComponent } from '../components/employee-list.component';
import { EmployeeDto } from '../models/employee';

@Component({
  selector: 'app-employees-page',
  standalone: true,
  imports: [CommonModule, EmployeeListComponent],
  template: `
    <div class="max-w-7xl mx-auto px-4 py-8">
      <h1 class="text-4xl font-bold text-gray-900 mb-8">All Employees</h1>
      
      <app-employee-list 
        [employees]="employees()"
        [isLoading]="isLoading()"
        [errorMessage]="errorMessage()"
        (deleteEmployee)="onDeleteEmployee($event)"
        (searchChange)="onSearchChange($event)"
      />
    </div>
  `
})
export class EmployeesPageComponent implements OnInit {
  private employeeService = inject(EmployeeService);

  employees = signal<EmployeeDto[]>([]);
  isLoading = signal(false);
  errorMessage = signal('');

  ngOnInit(): void {
    this.loadEmployees();
  }

  loadEmployees(): void {
    this.isLoading.set(true);
    this.errorMessage.set('');

    this.employeeService.getAllEmployees().subscribe({
      next: (data) => {
        this.employees.set(data);
        this.isLoading.set(false);
      },
      error: (err) => {
        console.error('Error loading employees:', err);
        this.errorMessage.set('Failed to load employees. Please try again.');
        this.isLoading.set(false);
      }
    });
  }

  onDeleteEmployee(id: number): void {
    this.isLoading.set(true);
    this.employeeService.deleteEmployee(id).subscribe({
      next: () => {
        this.employees.set(this.employees().filter(e => e.id !== id));
        this.isLoading.set(false);
      },
      error: (err) => {
        console.error('Error deleting employee:', err);
        this.errorMessage.set('Failed to delete employee. Please try again.');
        this.isLoading.set(false);
      }
    });
  }

  onSearchChange(term: string): void {
    // Search is handled client-side in the component
  }
}
