import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [CommonModule, RouterLink, RouterLinkActive],
  template: `
    <nav class="bg-white shadow-md sticky top-0 z-50">
      <div class="max-w-7xl mx-auto px-4 py-4 flex items-center justify-between">
        <div class="flex items-center gap-2">
          <div class="text-2xl font-bold text-blue-600">👥</div>
          <h1 class="text-2xl font-bold text-gray-900">Employee Manager</h1>
        </div>
        
        <div class="flex gap-6">
          <a 
            routerLink="/employees" 
            routerLinkActive="text-blue-600 border-b-2 border-blue-600"
            [routerLinkActiveOptions]="{ exact: true }"
            class="text-gray-700 hover:text-blue-600 pb-1 transition-colors"
          >
            List
          </a>
          <a 
            routerLink="/search" 
            routerLinkActive="text-blue-600 border-b-2 border-blue-600"
            [routerLinkActiveOptions]="{ exact: true }"
            class="text-gray-700 hover:text-blue-600 pb-1 transition-colors"
          >
            Search
          </a>
          <a 
            routerLink="/create" 
            routerLinkActive="text-blue-600 border-b-2 border-blue-600"
            [routerLinkActiveOptions]="{ exact: true }"
            class="text-gray-700 hover:text-blue-600 pb-1 transition-colors"
          >
            Add Employee
          </a>
        </div>
      </div>
    </nav>
  `
})
export class NavbarComponent {}
