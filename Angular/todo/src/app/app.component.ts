import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { Todo } from '../models/todo.model';

@Component({
  selector: 'app-root', // <app-root>
  standalone: true,
  imports: [CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'My Tasks';
  public todos: Todo[] = [];


  constructor() {
    this.todos.push(new Todo(1, 'Walk with dog', false));
    this.todos.push(new Todo(2 , 'Cut the hair', true));
    this.todos.push(new Todo(3, 'Go to market', false));
    
  }
}
