import { Component, OnInit } from '@angular/core';
import { AccountService } from '../../services/account.service';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { ProfileService } from '../../services/profile.service';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {
  isLoginError: boolean = false;
  constructor(private accountService: AccountService, private profileService: ProfileService, private router: Router) { }

  ngOnInit() {
  }

  OnSubmit(userName, password) {
    this.accountService.userAuthentication(userName, password).
      subscribe((data: any) => {
        localStorage.setItem('userToken', data.access_token);
        this.router.navigate(['/home']);
      },
        (err: HttpErrorResponse) => {
          this.isLoginError = true;
        });
  }
}
