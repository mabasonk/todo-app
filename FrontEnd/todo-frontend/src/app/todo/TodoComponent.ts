

import { Component, OnInit } from '@angular/core';
import { TodoService } from '../services/todo.service';
import { TodoItem } from '../models/todo-item';

@Component({
  selector: 'app-todo',
  templateUrl: './todo.component.html',
  styleUrls: ['./todo.component.css']
})
export class TodoComponent implements OnInit {
  todos: TodoItem[] = [];
  newTodo = '';

  constructor(private todoService: TodoService) {}

  ngOnInit(): void {
    this.loadTodos();
  }

  loadTodos(): void {
    this.todoService.getTodos().subscribe(todos => this.todos = todos);
  }

  addTodo(): void {
    if (!this.newTodo.trim()) return;
    const newItem = { name: this.newTodo, isComplete: false };
    this.todoService.addTodo(newItem).subscribe(todo => {
      this.todos.push(todo);
      this.newTodo = '';
    });
  }

  toggleComplete(todo: TodoItem): void {
    const updated = { ...todo, isComplete: !todo.isComplete };
    this.todoService.updateTodo(updated).subscribe(() => {
      todo.isComplete = updated.isComplete;
    });
  }

  deleteTodo(id: number): void {
    this.todoService.deleteTodo(id).subscribe(() => {
      this.todos = this.todos.filter(t => t.id !== id);
    });
  }
}