import { Component, inject, signal } from '@angular/core';
import { RouterLink } from '@angular/router';
import { UserService } from '../services/user-service';
import { defaultGetAllUser } from '../models/user.model';

@Component({
  standalone :true,
  selector: 'app-dashboardpad',
  imports: [RouterLink],
  templateUrl: './dashboardpad.component.html',
  styleUrl: './dashboardpad.component.scss',
})
export class Dashboardpad {
  private userService = inject(UserService);
  params = signal(defaultGetAllUser());
  private getAllUserRef = this.userService.getAllUsers(this.params);
  // private getAllUserRef = this.userService.getAllUsers();

  isloading = this.getAllUserRef.isLoading;
  iserror = this.getAllUserRef.error;
  value = this.getAllUserRef.value;

}
