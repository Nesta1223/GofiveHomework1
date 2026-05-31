import { Routes } from '@angular/router';
import { Dashboardpad } from './features/dashboard/dashboardpad/dashboardpad.component';
import { AddUser } from './features/dashboard/add-user/add-user';

export const routes: Routes = [
    {
        path: 'dashboard/pad',
        component: Dashboardpad 
        
    },
    {
        path: 'dashboard/pad/add',
        component : AddUser
    }
];
