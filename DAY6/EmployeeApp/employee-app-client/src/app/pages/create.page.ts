import { Component, signal, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { EmployeeService } from '../services/employee.service';
import { EmployeeFormComponent } from '../components/employee-form.component';
import { CreateEmployeeRequest } from '../models/employee';

@Component({
  selector: 'app-create-page',
  standalone: true,
  imports: [CommonModule, EmployeeFormComponent],
  template: `
    <div class="max-w-7xl mx-auto px-4 py-8">
      <h1 class="text-4xl font-bold text-gray-900 mb-8">Create New Employee</h1>
      
      <div class="mb-4">
        <div *ngIf="successMessage()" class="bg-green-50 border border-green-200 p-4 rounded-lg flex items-center gap-2">
          <span class="text-2xl">✅</span>
          <div>
            <p class="text-green-800 font-semibold">{{ successMessage() }}</p>
            <p class="text-green-700 text-sm mt-1">Redirecting to employee list...</p>
          </div>
        </div>
      </div>

      <app-employee-form (submit)="onSubmit($event)" />
    </div>
  `
})
export class CreateEmployeePageComponent {
  private employeeService = inject(EmployeeService);
  private router = inject(Router);

  successMessage = signal('');
  isSubmitting = signal(false);

  onSubmit(employee: CreateEmployeeRequest): void {
    this.isSubmitting.set(true);

    this.employeeService.createEmployee(employee).subscribe({
      next: (newEmployee) => {
        this.successMessage.set(`Employee ${newEmployee.firstName} ${newEmployee.lastName} created successfully!`);
        this.isSubmitting.set(false);

        // Redirect after 2 seconds
        setTimeout(() => {
          this.router.navigate(['/employees']);
        }, 2000);
      },
      error: (err) => {
        console.error('Error creating employee:', err);
        this.isSubmitting.set(false);
        // Error is handled in the form component
      }
    });
  }
}
