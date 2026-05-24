import { HttpClient, httpResource } from '@angular/common/http';
import { inject, Injectable, Signal, signal } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { GetAllUser, User } from '../models/user.model';

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

  // getAllUsers(){
  //   return httpResource<User[]>(() =>`${this.apiBaseUrl}/api/Users`);//reserves
  // }
}

