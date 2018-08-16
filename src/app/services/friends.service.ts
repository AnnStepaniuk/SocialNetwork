import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import 'rxjs/add/operator/map';
import { Message } from '../models/message.model';
import { ReceivedMessage } from '../models/receivedMessage.model';
import { Observable } from 'rxjs/Observable';
import { SentMessage } from '../models/sentMessage.model';

@Injectable()
export class FriendsService {
    readonly rootUrl = 'http://localhost:57609/api';
    obj;
    constructor(private http: HttpClient) { }

    getListFriends(id: number) {
        return this.http.get(this.rootUrl + '/friends/get/' + id);
    }

    sendMessage(message: Message) {
        console.log(message.MessageDate);
        return this.http.post(this.rootUrl + '/messages/send', message);
    }

    getReceivedMessages(userId: number): Observable<ReceivedMessage> {
        return this.http.get<ReceivedMessage>(this.rootUrl + '/messages/getReceived/' + userId);
    }

    getSentMessages(userId: number): Observable<SentMessage> {
        return this.http.get<SentMessage>(this.rootUrl + '/messages/getSent/' + userId);
    }

    deleteMessage(messageId: number) {
        return this.http.delete(this.rootUrl + '/messages/' + messageId);
    }

   
}