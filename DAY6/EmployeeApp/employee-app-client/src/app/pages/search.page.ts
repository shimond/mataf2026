import { Component, signal, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmployeeService } from '../services/employee.service';
import { EmployeeListComponent } from '../components/employee-list.component';
import { EmployeeDto } from '../models/employee';

@Component({
  selector: 'app-search-page',
  standalone: true,
  imports: [CommonModule, EmployeeListComponent],
  template: `
    <div class="max-w-7xl mx-auto px-4 py-8">
      <h1 class="text-4xl font-bold text-gray-900 mb-8">Search Employees</h1>
      
      <app-employee-list 
        [employees]="searchResults()"
        [isLoading]="isLoading()"
        [errorMessage]="errorMessage()"
        (deleteEmployee)="onDeleteEmployee($event)"
        (searchChange)="onSearchChange($event)"
      />
    </div>
  `
})
export class SearchPageComponent {
  private employeeService = inject(EmployeeService);

  searchResults = signal<EmployeeDto[]>([]);
  isLoading = signal(false);
  errorMessage = signal('');
  private debounceTimer: any;

  onSearchChange(term: string): void {
    clearTimeout(this.debounceTimer);
    
    if (!term.trim()) {
      this.searchResults.set([]);
      this.errorMessage.set('');
      return;
    }

    this.debounceTimer = setTimeout(() => {
      this.isLoading.set(true);
      this.errorMessage.set('');

      this.employeeService.searchEmployees(term).subscribe({
        next: (data) => {
          this.searchResults.set(data);
          this.isLoading.set(false);
        },
        error: (err) => {
          console.error('Error searching employees:', err);
          this.errorMessage.set('Failed to search employees. Please try again.');
          this.isLoading.set(false);
        }
      });
    }, 300); // 300ms debounce
  }

  onDeleteEmployee(id: number): void {
    this.isLoading.set(true);
    this.employeeService.deleteEmployee(id).subscribe({
      next: () => {
        this.searchResults.set(this.searchResults().filter(e => e.id !== id));
        this.isLoading.set(false);
      },
      error: (err) => {
        console.error('Error deleting employee:', err);
        this.errorMessage.set('Failed to delete employee. Please try again.');
        this.isLoading.set(false);
      }
    });
  }
}
