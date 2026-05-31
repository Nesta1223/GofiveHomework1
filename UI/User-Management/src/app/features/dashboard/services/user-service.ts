import { HttpClient, httpResource } from '@angular/common/http';
import { inject, Injectable, Signal, signal } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { AddUserRequest, GetAllUser, UpdateUserRequest, User } from '../models/user.model';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  //field
  private http = inject(HttpClient);
  private apiBaseUrl = environment.apiBaseUrl;

  addUserStatus = signal<'idle' |'loading' | 'success' |'error'>('idle');
  updateUserStatus = signal<'idle' |'loading' | 'success' |'error'>('idle');
  deleteUserStatus = signal<'idle' |'loading' | 'success' |'error'>('idle');
  //methods
  getAllUsers(params: Signal<GetAllUser>) {//maybe this not work
        return httpResource<User[]>(() => ({
          url: `${this.apiBaseUrl}/api/Users`,
          params: params() as unknown as Record<string, string | number | boolean>
      }));
  }

  addUser(user : AddUserRequest){
    this.addUserStatus.set('loading');
    this.http.post<void>(`${this.apiBaseUrl}/api/Users`,user)
    .subscribe({
      next:()=>{
        this.addUserStatus.set('success');
      },
      error:()=>{
        this.addUserStatus.set('error');
      }
    })
  }

  updateUser(user: UpdateUserRequest) {
    this.updateUserStatus.set('loading');
    this.http.put<void>(`${this.apiBaseUrl}/api/Users/${user.userId}`, user)
    .subscribe({
      next: () => {
        this.updateUserStatus.set('success');
      },
      error: () => {
        this.updateUserStatus.set('error');
      }
    });
  }

  deleteUser(id: string) {
    this.deleteUserStatus.set('loading');
    this.http.delete<void>(`${this.apiBaseUrl}/api/Users/${id}`)
    .subscribe({
      next: () => {
        this.deleteUserStatus.set('success');
      },
      error: () => {
        this.deleteUserStatus.set('error');
      }
    });
  }





  // getAllUsers(){
  //   return httpResource<User[]>(() =>`${this.apiBaseUrl}/api/Users`);//reserves
  // }
}

