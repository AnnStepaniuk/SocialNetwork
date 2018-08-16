import { Component, OnInit } from '@angular/core';
import { UserInform } from '../../models/userInform.model';
import { ReceivedRequest } from '../../models/receivedRequest.model';
import { SearchFriendsService } from '../../services/searchFriends.service';
import { ProfileService } from '../../services/profile.service';
import { Request } from '../../models/Request.model'
import * as $ from 'jquery'
import { SentRequest } from '../../models/sentRequest.model';

@Component({
  selector: 'app-friends-search',
  templateUrl: './friends-search.component.html',
  styleUrls: ['./friends-search.component.css']
})

export class FriendsSearchComponent implements OnInit {
  userId: number;
  currentPage = 0;
  pageSize = 4;
  users: UserInform[] = [];
  receivedRequests: ReceivedRequest[] = [];
  sentRequests: SentRequest[]=[];
  isLoading = false;
  finished = false;

  constructor(private searchFriendsService: SearchFriendsService, private profileService: ProfileService) { }

  ngOnInit() {
    this.profileService.getUser().subscribe(
      (data: UserInform) => {
        this.userId = data.UserId;
        this.searchFriendsService.getAllContacts(this.userId, this.currentPage, this.pageSize).subscribe((data: any) => {
          this.users.push(...data);
        });
        this.searchFriendsService.getReceivedRequests(this.userId).subscribe((data: any) => {
          this.receivedRequests.push(...data);
          $('#viewSent').show();
    $('#viewReceived').hide();
        });
      });


  }

  onScroll() {

    this.currentPage++;
    // onLoadClick() {
    console.log('scrolled!!')
    this.searchFriendsService.getAllContacts(this.userId, this.currentPage, this.pageSize).subscribe((data: any) => {
      this.users.push(...data);
      if (data.length == 0) {
        this.finished = true;
      }
    });

  }

  AddFriend(user: UserInform) {
    this.searchFriendsService.SendRequest(this.userId, user).subscribe(
      data => {
        console.log('added');
        var idx = this.users.indexOf(user);
        this.users.splice(idx, 1);
      }
    );
  }

  ConfirmRequest(receivedRequest: ReceivedRequest) {
    const request: Request = {
      SenderId: receivedRequest.Sender.UserId,
      ReceiverId: this.userId
    }
    this.searchFriendsService.ConfirmRequest(request).subscribe(
      data => {
        console.log('added');
        var idx = this.receivedRequests.indexOf(receivedRequest);
        this.receivedRequests.splice(idx, 1);
      }
    );
  }

  ClickOnViewReceived() {
    this.receivedRequests = [];
    this.sentRequests=[];
    this.searchFriendsService.getReceivedRequests(this.userId).subscribe((data: any) => {
      this.receivedRequests.push(...data);
    });
    $('#viewSent').show();
    $('#viewReceived').hide();
  }

  ClickOnViewSent() {
    this.receivedRequests = [];
    this.sentRequests = [];
    this.searchFriendsService.getSentRequests(this.userId).subscribe((data: any) => {
      this.sentRequests.push(...data);
    });
    $('#viewSent').hide();
    $('#viewReceived').show();
  }
}

