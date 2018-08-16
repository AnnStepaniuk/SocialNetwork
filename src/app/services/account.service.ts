import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';
import { UserAccount, Birthday } from '../models/userAccount.model';


@Injectable()
export class AccountService {
    readonly rootUrl = 'http://localhost:57609';
    obj;
    constructor(private http: HttpClient) { }

    registerUser(data: any) {
        console.log(data.value.Day);
        const body: UserAccount = {
            Email: data.value.Email,
            Password: data.value.Password,
            Birthday: data.value.Day + '/' + data.value.Month + '/' + data.value.Year,
            FirstName: data.value.FirstName,
            LastName: data.value.LastName,
            ConfirmPassword: data.value.ConfirmPassword
        }
        var reqHeader = new HttpHeaders({ 'No-Auth': 'True' });
        return this.http.post(this.rootUrl + '/api/Account/Register', body, { headers: reqHeader });
    }

    userAuthentication(userName, password) {
        console.log(userName);
        console.log(password);
        var data = "username=" + userName + "&password=" + password + "&grant_type=password";
        var reqHeader = new HttpHeaders({ 'Content-Type': 'application/x-www-urlencoded', 'No-Auth': 'True' });
        return this.http.post(this.rootUrl + '/token', data, { headers: reqHeader });
    }

}