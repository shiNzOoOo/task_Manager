import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, ActivatedRoute, RouterLink } from '@angular/router';
import { TaskService } from '../../services/task.service';
import { Task } from '../../models/task.model';

@Component({
  selector: 'app-task-form',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterLink],
  templateUrl: './task-form.component.html'
})
export class TaskFormComponent implements OnInit {
  taskForm: FormGroup;
  isEditMode = false;
  taskId?: number;
  isSubmitting = false;

  constructor(
    private fb: FormBuilder,
    private taskService: TaskService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.taskForm = this.fb.group({
      title: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(100)]],
      description: ['', [Validators.maxLength(500)]],
      isCompleted: [false]
    });
  }

  ngOnInit(): void {
    this.taskId = this.route.snapshot.params['id'] ? Number(this.route.snapshot.params['id']) : undefined;
    if (this.taskId) {
      this.isEditMode = true;
      this.taskService.getTask(this.taskId).subscribe({
        next: (task) => {
          this.taskForm.patchValue({
            title: task.title,
            description: task.description,
            isCompleted: task.isCompleted
          });
        },
        error: () => this.router.navigate(['/'])
      });
    }
  }

  onSubmit(): void {
    if (this.taskForm.invalid) return;

    this.isSubmitting = true;
    const taskData: Task = this.taskForm.value;

    if (this.isEditMode && this.taskId) {
      this.taskService.updateTask(this.taskId, taskData).subscribe({
        next: () => this.router.navigate(['/']),
        error: (err) => {
          console.error(err);
          this.isSubmitting = false;
        }
      });
    } else {
      this.taskService.createTask(taskData).subscribe({
        next: () => this.router.navigate(['/']),
        error: (err) => {
          console.error(err);
          this.isSubmitting = false;
        }
      });
    }
  }
}
