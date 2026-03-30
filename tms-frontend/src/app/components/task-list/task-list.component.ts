import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { Task } from '../../models/task.model';
import { TaskService } from '../../services/task.service';

@Component({
  selector: 'app-task-list',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './task-list.component.html'
})
export class TaskListComponent implements OnInit {
  tasks: Task[] = [];
  isLoading = true;
  error = '';

  constructor(private taskService: TaskService) {}

  ngOnInit(): void {
    this.loadTasks();
  }

  loadTasks(): void {
    this.isLoading = true;
    this.taskService.getTasks().subscribe({
      next: (data) => {
        this.tasks = data;
        this.isLoading = false;
      },
      error: (err) => {
        this.error = 'Failed to load tasks. Please ensure the API is running.';
        this.isLoading = false;
        console.error(err);
      }
    });
  }

  deleteTask(id: number | undefined): void {
    if (!id) return;
    if (confirm('Are you sure you want to delete this task?')) {
      this.taskService.deleteTask(id).subscribe({
        next: () => this.loadTasks(),
        error: (err) => console.error(err)
      });
    }
  }

  toggleCompletion(task: Task): void {
    const updatedTask = { ...task, isCompleted: !task.isCompleted };
    this.taskService.updateTask(task.id!, updatedTask).subscribe({
      next: () => this.loadTasks(),
      error: (err) => console.error(err)
    });
  }
}
