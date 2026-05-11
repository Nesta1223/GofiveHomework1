import { Routes } from '@angular/router';
import { Dashboardpad } from './features/dashboard/dashboardpad/dashboardpad';

export const routes: Routes = [
    {
        path: 'dashboard',
        children: [
            { path: 'pad', component: Dashboardpad }
        ]
    }
];
