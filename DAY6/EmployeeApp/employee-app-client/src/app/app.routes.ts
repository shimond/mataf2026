import { Routes } from '@angular/router';
import { EmployeesPageComponent } from './pages/employees.page';
import { SearchPageComponent } from './pages/search.page';
import { CreateEmployeePageComponent } from './pages/create.page';

export const routes: Routes = [
  { path: '', redirectTo: '/employees', pathMatch: 'full' },
  { path: 'employees', component: EmployeesPageComponent },
  { path: 'search', component: SearchPageComponent },
  { path: 'create', component: CreateEmployeePageComponent },
  { path: '**', redirectTo: '/employees' }
];
