import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TodoItem } from '../models/todo-item';

@Injectable({
  providedIn: 'root'
})
export class TodoService {
  private apiUrl = 'https://localhost:5001/api/todoitems';

  constructor(private http: HttpClient) {}

  getTodos(): Observable<TodoItem[]> {
    return this.http.get<TodoItem[]>(this.apiUrl);
  }

  addTodo(todo: Partial<TodoItem>): Observable<TodoItem> {
    return this.http.post<TodoItem>(this.apiUrl, todo);
  }

  deleteTodo(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }

  updateTodo(todo: TodoItem): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${todo.id}`, todo);
  }
}
