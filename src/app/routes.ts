import { Routes } from '@angular/router';
import { UserComponent } from './user/user.component';
import { SignUpComponent } from './user/sign-up/sign-up.component';
import { SignInComponent } from './user/sign-in/sign-in.component';
import { AuthGuard } from './auth/auth.guard';
import { HomeComponent } from './components/home/home.component';
import { ProfileComponent } from './components/profile/profile.component';
import { FriendsComponent } from './components/friends/friends.component';
import { FriendsSearchComponent } from './components/friends-search/friends-search.component';
import { MessageComponent } from './components/message/message.component';

export const appRoutes: Routes = [
    { path: 'home', redirectTo: '/profile', pathMatch: 'full', canActivate:[AuthGuard] },
    {
        path: 'signup', component: UserComponent, 
        children: [{ path: '', component: SignUpComponent }]
    },
    {
        path: 'login', component: UserComponent,
        children: [{ path: '', component: SignInComponent }]
    },
    { path: '', redirectTo: '/login', pathMatch: 'full' },

    {
        path: 'profile', component: HomeComponent,  
        children: [{ path: '', component: ProfileComponent }]
    },   
    {
        path: 'friends', component: HomeComponent, canActivate:[AuthGuard],
        children: [{ path: '', component: FriendsComponent }]
    },
    {
        path: 'friendsSearch', component: HomeComponent, canActivate:[AuthGuard],
        children: [{ path: '', component: FriendsSearchComponent }]
    },
    {
        path: 'messages', component: HomeComponent, canActivate:[AuthGuard],
        children: [{ path: '', component: MessageComponent }]
    },
    
]