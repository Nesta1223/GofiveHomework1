import { Component, effect, inject, input, output } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { UserService } from '../services/user-service';
import { UpdateUserRequest, User } from '../models/user.model';

@Component({
  selector: 'app-edit-user',
  imports: [ReactiveFormsModule],
  templateUrl: './edit-user.html',
  styleUrl: './edit-user.scss',
})
export class EditUser {

  user = input.required<User>();
  editUserSuccess = output<void>();

  private service = inject(UserService);

  editUserFormGroup = new FormGroup({
    userId:    new FormControl<string>(''),
    firstName: new FormControl<string>(''),
    lastName:  new FormControl<string>(''),
    email:     new FormControl<string>(''),
    phone:     new FormControl<string>(''),
    roleId:    new FormControl<string>(''),
    username:  new FormControl<string>(''),
    password:  new FormControl<string>(''),
  });

  constructor() {
    effect(() => {
      const u = this.user();
      this.editUserFormGroup.patchValue({
        userId:    u.userId,
        firstName: u.firstName,
        lastName:  u.lastName,
        email:     u.email,
        phone:     u.phone,
        roleId:    u.role.roleId,
        username:  u.username,
      });
    });

    effect(() => {
      if (this.service.updateUserStatus() === 'success') {
        this.service.updateUserStatus.set('idle');
        this.editUserSuccess.emit();
      }
      if (this.service.updateUserStatus() === 'error') {
        console.error('Update user request failed');
      }
    });
  }

  getUserIdFormControl()    { return this.editUserFormGroup.controls.userId; }
  getFirstNameFormControl() { return this.editUserFormGroup.controls.firstName; }
  getLastNameFormControl()  { return this.editUserFormGroup.controls.lastName; }
  getEmailFormControl()     { return this.editUserFormGroup.controls.email; }
  getPhoneFormControl()     { return this.editUserFormGroup.controls.phone; }
  getRoleIdFormControl()    { return this.editUserFormGroup.controls.roleId; }
  getUsernameFormControl()  { return this.editUserFormGroup.controls.username; }
  getPasswordFormControl()  { return this.editUserFormGroup.controls.password; }

  onSubmit() {
    const v = this.editUserFormGroup.getRawValue();
    const updateUserDto: UpdateUserRequest = {
      userId:    v.userId    ?? '',
      firstName: v.firstName ?? '',
      lastName:  v.lastName  ?? '',
      email:     v.email     ?? '',
      phone:     v.phone     ?? '',
      roleId:    v.roleId    ?? '',
      username:  v.username  ?? '',
      password:  v.password  ?? '',
    };
    this.service.updateUser(updateUserDto);
  }
}
