import { Component, input, output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { EmployeeDto } from '../models/employee';

@Component({
  selector: 'app-employee-card',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './employee-card.component.html'
})
export class EmployeeCardComponent {
  employee = input.required<EmployeeDto>();
  editMode = input(false);
  deleteClick = output<number>();
  editClick = output<Partial<EmployeeDto>>();

  isEditMode = input(false);
  
  editData = { email: '', salary: 0 };

  toggleEditMode(): void {
    const emp = this.employee();
    if (!this.isEditMode()) {
      this.editData = {
        email: emp.email,
        salary: emp.salary
      };
    }
  }

  saveEdit(): void {
    const emp = this.employee();
    this.editClick.emit({
      id: emp.id,
      email: this.editData.email,
      salary: this.editData.salary
    });
    this.toggleEditMode();
  }

  onDelete(): void {
    const emp = this.employee();
    const name = emp.firstName + ' ' + emp.lastName;
    const msg = 'Are you sure you want to delete ' + name + '?';
    if (confirm(msg)) {
      this.deleteClick.emit(emp.id);
    }
  }

  formatDate(date: string | Date): string {
    const d = new Date(date);
    return d.toLocaleDateString('en-US', { 
      year: 'numeric', 
      month: 'short', 
      day: 'numeric' 
    });
  }

  formatSalary(salary: number): string {
    return salary.toLocaleString('en-US', { 
      minimumFractionDigits: 2, 
      maximumFractionDigits: 2 
    });
  }
}
