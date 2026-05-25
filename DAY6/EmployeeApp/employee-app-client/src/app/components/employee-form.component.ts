import { Component, output, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CreateEmployeeRequest } from '../models/employee';

@Component({
  selector: 'app-employee-form',
  standalone: true,
  imports: [CommonModule, FormsModule],
  template: `
    <form (ngSubmit)="onSubmit()" class="bg-white p-6 rounded-lg shadow-md max-w-2xl mx-auto">
      <h2 class="text-2xl font-bold mb-6 text-gray-900">Create New Employee</h2>
      
      <div class="grid grid-cols-1 md:grid-cols-2 gap-4 mb-4">
        <!-- First Name -->
        <div>
          <label class="block text-sm font-medium text-gray-700 mb-1">First Name *</label>
          <input 
            type="text"
            [(ngModel)]="formData.firstName"
            name="firstName"
            class="input-field"
            placeholder="John"
            required
          />
          <div class="error-text" *ngIf="errors()['firstName']">{{ errors()['firstName'] }}</div>
        </div>

        <!-- Last Name -->
        <div>
          <label class="block text-sm font-medium text-gray-700 mb-1">Last Name *</label>
          <input 
            type="text"
            [(ngModel)]="formData.lastName"
            name="lastName"
            class="input-field"
            placeholder="Doe"
            required
          />
          <div class="error-text" *ngIf="errors()['lastName']">{{ errors()['lastName'] }}</div>
        </div>
      </div>

      <!-- Email -->
      <div class="mb-4">
        <label class="block text-sm font-medium text-gray-700 mb-1">Email *</label>
        <input 
          type="email"
          [(ngModel)]="formData.email"
          name="email"
          class="input-field"
          placeholder="john.doe@example.com"
          required
        />
        <div class="error-text" *ngIf="errors()['email']">{{ errors()['email'] }}</div>
      </div>

      <!-- Birthdate -->
      <div class="mb-4">
        <label class="block text-sm font-medium text-gray-700 mb-1">Birthdate *</label>
        <input 
          type="date"
          [(ngModel)]="formData.birthdate"
          name="birthdate"
          class="input-field"
          required
        />
        <div class="error-text" *ngIf="errors()['birthdate']">{{ errors()['birthdate'] }}</div>
        <div class="text-xs text-gray-500 mt-1" *ngIf="formData.birthdate">
          Age: {{ calculateAge(formData.birthdate) }} years
        </div>
      </div>

      <!-- Salary -->
      <div class="mb-6">
        <label class="block text-sm font-medium text-gray-700 mb-1">Salary *</label>
        <input 
          type="number"
          [(ngModel)]="formData.salary"
          name="salary"
          class="input-field"
          placeholder="75000"
          min="0"
          required
        />
        <div class="error-text" *ngIf="errors()['salary']">{{ errors()['salary'] }}</div>
      </div>

      <!-- Error Message -->
      <div class="error-text mb-4" *ngIf="errorMessage()">{{ errorMessage() }}</div>

      <!-- Buttons -->
      <div class="flex gap-3 justify-end">
        <button 
          type="button"
          (click)="onReset()"
          class="btn-secondary"
        >
          Clear
        </button>
        <button 
          type="submit"
          class="btn-primary"
          [disabled]="isSubmitting()"
        >
          <span *ngIf="!isSubmitting()">Create Employee</span>
          <span *ngIf="isSubmitting()" class="flex items-center gap-2">
            <svg class="loading-spinner h-4 w-4" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24">
              <circle class="opacity-25" cx="12" cy="12" r="10" stroke="currentColor" stroke-width="4"></circle>
              <path class="opacity-75" fill="currentColor" d="M4 12a8 8 0 018-8V0C5.373 0 0 5.373 0 12h4zm2 5.291A7.962 7.962 0 014 12H0c0 3.042 1.135 5.824 3 7.938l3-2.647z"></path>
            </svg>
            Creating...
          </span>
        </button>
      </div>
    </form>
  `
})
export class EmployeeFormComponent {
  formData = {
    firstName: '',
    lastName: '',
    email: '',
    birthdate: '',
    salary: 0
  };

  errors = signal<Record<string, string>>({});
  errorMessage = signal('');
  isSubmitting = signal(false);

  submit = output<CreateEmployeeRequest>();

  calculateAge(birthdate: string | Date): number {
    const birth = new Date(birthdate);
    const today = new Date();
    let age = today.getFullYear() - birth.getFullYear();
    const monthDiff = today.getMonth() - birth.getMonth();
    if (monthDiff < 0 || (monthDiff === 0 && today.getDate() < birth.getDate())) {
      age--;
    }
    return age;
  }

  validateForm(): boolean {
    const newErrors: Record<string, string> = {};

    if (!this.formData.firstName.trim()) {
      newErrors['firstName'] = 'First name is required';
    }
    if (!this.formData.lastName.trim()) {
      newErrors['lastName'] = 'Last name is required';
    }
    if (!this.formData.email.trim()) {
      newErrors['email'] = 'Email is required';
    } else if (!this.isValidEmail(this.formData.email)) {
      newErrors['email'] = 'Please enter a valid email';
    }
    if (!this.formData.birthdate) {
      newErrors['birthdate'] = 'Birthdate is required';
    }
    if (!this.formData.salary || this.formData.salary <= 0) {
      newErrors['salary'] = 'Salary must be greater than 0';
    }

    this.errors.set(newErrors);
    return Object.keys(newErrors).length === 0;
  }

  isValidEmail(email: string): boolean {
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailRegex.test(email);
  }

  onSubmit(): void {
    this.errorMessage.set('');
    if (!this.validateForm()) {
      return;
    }

    const employeeData = {
      firstName: this.formData.firstName,
      lastName: this.formData.lastName,
      email: this.formData.email,
      birthdate: this.formData.birthdate,
      salary: this.formData.salary
    };

    this.submit.emit(employeeData);
  }

  onReset(): void {
    this.formData = {
      firstName: '',
      lastName: '',
      email: '',
      birthdate: '',
      salary: 0
    };
    this.errors.set({});
    this.errorMessage.set('');
  }
}
