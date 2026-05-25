export interface EmployeeDto {
  id: number;
  firstName: string;
  lastName: string;
  email: string;
  birthdate: string | Date;
  salary: number;
  age: number;
}

export interface CreateEmployeeRequest {
  firstName: string;
  lastName: string;
  email: string;
  birthdate: string | Date;
  salary: number;
}
