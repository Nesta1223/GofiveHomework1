import { Component, effect, inject, output } from '@angular/core';
import { UserService } from '../services/user-service';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { AddUserRequest } from '../models/user.model';

@Component({
  selector: 'app-add-user',
  imports: [ReactiveFormsModule],
  templateUrl: './add-user.html',
  styleUrl: './add-user.scss',
})
export class AddUser {

  addUserSuccess = output<void>();

  constructor() {
    effect(() =>{
      if (this.service.addUserStatus() == 'success'){
        this.service.addUserStatus.set('idle');
        this.addUserSuccess.emit();
      }
      if (this.service.addUserStatus() == 'error'){
        console.error('Add user request fail');
      }
    })
  }

  private service = inject(UserService);

  addUserFormGroup  = new FormGroup({
    userId: new FormControl<string>(''),
    firstName : new FormControl<string>(''),
    lastName: new FormControl<string>(''),
    email : new FormControl<string>(''),
    phone : new FormControl<string>(''),
    roleId : new FormControl<string>(''),
    username: new FormControl<string>(''),
    password: new FormControl<string>(''),
  });

  getUserIdFormControl(){
    return this.addUserFormGroup.controls.userId;
  }

  getFirstNameFormControl(){
    return this.addUserFormGroup.controls.firstName;
  }

  getLastNameFormControl(){
    return this.addUserFormGroup.controls.lastName;
  }

  getEmailFormControl(){
    return this.addUserFormGroup.controls.email;
  }

  getPhoneFormControl(){
    return this.addUserFormGroup.controls.phone;
  }

  getRoleIdFormControl(){
    return this.addUserFormGroup.controls.roleId;
  }

  getUsernameFormControl(){
    return this.addUserFormGroup.controls.username;
  }

  getPasswordFormControl(){
    return this.addUserFormGroup.controls.password;
  }

  onSubmit(){
    const addUserFormValue = this.addUserFormGroup.getRawValue();

    const addUserDto :AddUserRequest = {
      userId : addUserFormValue.userId ?? '',
      firstName : addUserFormValue.firstName ?? '',
      lastName : addUserFormValue.lastName ?? '',
      email : addUserFormValue.email ?? '',
      phone : addUserFormValue.phone ?? '',
      roleId : addUserFormValue.roleId ?? '',
      username : addUserFormValue.username ?? '',
      password : addUserFormValue.password ?? '',
    }
    
    this.service.addUser(addUserDto);
  }
}
