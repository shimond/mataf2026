import { Component, input, output, signal, effect } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { EmployeeDto } from '../models/employee';
import { EmployeeCardComponent } from './employee-card.component';

@Component({
  selector: 'app-employee-list',
  standalone: true,
  imports: [CommonModule, FormsModule, EmployeeCardComponent],
  templateUrl: './employee-list.component.html'
})
export class EmployeeListComponent {
  employees = input.required<EmployeeDto[]>();
  isLoading = input(false);
  errorMessage = input('');
  
  deleteEmployee = output<number>();
  searchChange = output<string>();

  viewMode = signal<'table' | 'card'>('table');
  searchTerm = signal('');
  filteredEmployees = signal<EmployeeDto[]>([]);
  allEmployees = signal<EmployeeDto[]>([]);

  constructor() {
    effect(() => {
      this.allEmployees.set(this.employees());
      this.updateFilteredEmployees();
    });
  }

  toggleViewMode(mode?: 'table' | 'card'): void {
    if (mode) {
      this.viewMode.set(mode);
    } else {
      this.viewMode.set(this.viewMode() === 'table' ? 'card' : 'table');
    }
  }

  onSearchChange(term: string): void {
    this.searchTerm.set(term);
    this.searchChange.emit(term);
    this.updateFilteredEmployees();
  }

  updateFilteredEmployees(): void {
    const term = this.searchTerm().toLowerCase();
    const filtered = this.allEmployees().filter(emp => 
      `${emp.firstName} ${emp.lastName}`.toLowerCase().includes(term) ||
      emp.email.toLowerCase().includes(term)
    );
    this.filteredEmployees.set(filtered);
  }

  onDelete(id: number): void {
    if (confirm('Are you sure you want to delete this employee?')) {
      this.deleteEmployee.emit(id);
    }
  }

  formatSalary(salary: number): string {
    return salary.toLocaleString('en-US', { 
      minimumFractionDigits: 2, 
      maximumFractionDigits: 2 
    });
  }
}
