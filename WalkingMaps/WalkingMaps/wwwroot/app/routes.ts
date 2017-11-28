import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


import { WalksComponent } from './components/walks.component';
import { WalkSightsComponent } from './components/walk-sights.component';

const appRoutes: Routes = [

    {
        path: '',
        redirectTo: '/walks',
        pathMatch: 'full'
    },
    {
        path: 'walks',
        component: WalksComponent
    },
    {
        path: 'walks/:id/sights',
        component: WalkSightsComponent
    }
];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);
