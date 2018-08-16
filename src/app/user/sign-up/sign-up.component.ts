import { Component, OnInit, Directive } from '@angular/core';
import { NgForm, EmailValidator } from '@angular/forms';

import { UserAccount, Birthday } from '../../models/userAccount.model';
import { AccountService } from '../../services/account.service'


@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {

  userAccount: UserAccount;
  birthday: Birthday;

  constructor(private accountService: AccountService) { }

  ngOnInit() {
    this.resetForm();
  }

  resetForm(form?: NgForm) {
    if (form != null)
      form.reset();
    this.userAccount = {
      FirstName: '',
      LastName: '',
      Birthday: '',
      Email: '',
      Password: '',
      ConfirmPassword: ''
    }
  }

  OnSubmit(form: NgForm) {
    console.log(form.value.Email);
    console.log(form.value.Day);
    this.accountService.registerUser(form).
      subscribe((data: any) => {
        if (data.Succeeded == true)
          this.resetForm(form);
      });
  }
}
