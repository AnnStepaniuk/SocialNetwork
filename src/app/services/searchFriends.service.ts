import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http'
import { Observable } from 'rxjs'
import 'rxjs/add/operator/map'
import { User } from '../auth/user.model';
import { createWiresService } from 'selenium-webdriver/firefox';
import { UserInform } from '../models/userInform.model';
import { UsersPage } from '../models/users-page';
import { NgForm } from '@angular/forms';
import { UserAccount, Birthday } from '../models/userAccount.model';
import { Request } from '../models/Request.model'

@Injectable()
export class SearchFriendsService {
    readonly rootUrl = 'http://localhost:57609/api/searchFriends';
    obj;
    constructor(private http: HttpClient) { }

    getReceivedRequests(id: number) {
        return this.http.get(this.rootUrl + '/requests/getReceived/' + id);
    }

    
    getSentRequests(id: number) {
        return this.http.get(this.rootUrl + '/requests/getSent/' + id);
    }

    getAllContacts(id: number, pageIndex: number, pageSize: number): Observable<UsersPage> {
        return this.http.get<UsersPage>(this.rootUrl + '/getContacts/' + id + '/' + pageIndex + '/' + pageSize);
    }

    SendRequest(id: number, user: UserInform) {
        console.log('user.Email ' + user.Email);
        console.log('user.FirstName ' + user.FirstName);
        const body: Request = {
            SenderId: id,
            ReceiverId: user.UserId
        }
        return this.http.post(this.rootUrl + '/request/send', body);
    }

    ConfirmRequest( request: Request) {
        return this.http.post(this.rootUrl + '/request/confirm', request);
    }

    

}