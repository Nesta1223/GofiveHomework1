import { Component, effect, inject, signal } from '@angular/core';
import { RouterLink } from '@angular/router';
import { UserService } from '../services/user-service';
import { defaultGetAllUser, User } from '../models/user.model';
import { AddUser } from '../add-user/add-user';
import { EditUser } from '../edit-user/edit-user';

@Component({
  standalone :true,
  selector: 'app-dashboardpad',
  imports: [RouterLink, AddUser, EditUser],
  templateUrl: './dashboardpad.component.html',
  styleUrl: './dashboardpad.component.scss',
})
export class Dashboardpad {
  private userService = inject(UserService);
  params = signal(defaultGetAllUser());
  private getAllUserRef = this.userService.getAllUsers(this.params);

  isloading = this.getAllUserRef.isLoading;
  iserror = this.getAllUserRef.error;
  value = this.getAllUserRef.value;

  showAddUser = signal(false);
  showEditUser = signal(false);
  selectedUser = signal<User | null>(null);

  constructor() {
    effect(() => {
      if (this.userService.deleteUserStatus() === 'success') {
        this.userService.deleteUserStatus.set('idle');
        this.getAllUserRef.reload();
      }
    });
  }

  onAddUserSuccess() {
    this.showAddUser.set(false);
    this.getAllUserRef.reload();
  }

  onEditUser(user: User) {
    this.selectedUser.set(user);
    this.showEditUser.set(true);
  }

  onEditUserSuccess() {
    this.showEditUser.set(false);
    this.selectedUser.set(null);
    this.getAllUserRef.reload();
  }

  onDeleteUser(userId: string) {
    this.userService.deleteUser(userId);
  }
}
