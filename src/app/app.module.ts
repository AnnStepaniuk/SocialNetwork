import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router'

import { AppComponent } from './app.component';

import { AccountService } from './services/account.service';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { UserComponent } from './user/user.component';
import { SignInComponent } from './user/sign-in/sign-in.component';
import { SignUpComponent } from './user/sign-up/sign-up.component';
import { appRoutes } from './routes';
import { AuthGuard } from './auth/auth.guard';
import { AuthInterceptor } from './auth/auth.interceptor';
import { InfiniteScrollModule } from 'ngx-infinite-scroll'
import { ConfirmEqualValidator } from './user/sign-up/equal-validator.directive';
import { FriendsService } from './services/friends.service';
import { SearchFriendsService } from './services/searchFriends.service';
import { MessageComponent } from './components/message/message.component';
import { FriendsSearchComponent } from './components/friends-search/friends-search.component';
import { FriendsComponent } from './components/friends/friends.component';
import { HomeComponent } from './components/home/home.component';
import { ProfileComponent } from './components/profile/profile.component';
import { ProfileService } from 'src/app/services/profile.service';

@NgModule({
  declarations: [
    AppComponent,

    // ListUsersComponent,
    // SingleUserComponent,
    // CreateUserComponent,
    // DeleteUserComponent,
    SignUpComponent,
    UserComponent,
    SignInComponent,
    HomeComponent,
    ProfileComponent,
    FriendsSearchComponent,
    ConfirmEqualValidator,
    FriendsComponent,
    MessageComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),
    InfiniteScrollModule
    // ServicesModule
  ],
  exports: [RouterModule],
  providers: [
    AccountService,
    ProfileService, 
    FriendsService,
    SearchFriendsService,
    AuthGuard,
    ,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
