import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { UserInform } from '../../models/userInform.model';
import { FriendsService } from '../../services/friends.service';
import * as $ from 'jquery'
import { User } from '../../auth/user.model';
import { ProfileService } from '../../services/profile.service';
import { NgForm } from '@angular/forms';
import { Message } from '../../models/message.model';

@Component({
  selector: 'app-friends',
  templateUrl: './friends.component.html',
  styleUrls: ['./friends.component.css']
})
export class FriendsComponent implements OnInit {
  users: UserInform[] = [];
  userId: number;
  nameFriend: string;
  idFriend: number;
  success:boolean = false;
  date: Date

  constructor(public ele: ElementRef, private friendsService: FriendsService, private profileService: ProfileService) { }

  ngOnInit() {
    this.profileService.getUser().subscribe(
      (data: UserInform) => {
        this.userId = data.UserId;
        this.friendsService.getListFriends(this.userId).subscribe((data: any) => {
          this.users.push(...data);
        });

      });
    // $(this.ele.nativeElement).find('button').on('click', function () {
    //   alert("yrrrraaa");
    // })
  }

  clickMessage(friend: UserInform) {
    this.nameFriend = friend.FirstName + ' ' + friend.LastName;
    this.idFriend = friend.UserId;
  }

  OnSendMessage(messageText: string) {
    this.date=new Date();
    console.log( this.date );
    console.log('onSend');
    var message:Message={
      SenderId:this.userId,
      ReceiverId:this.idFriend,
      MessageText:messageText,
      MessageDate: this.date
    };
    this.friendsService.sendMessage(message).subscribe(
     
      
    );
    $('#close').click();
    $('#successButton').click();
    
  }
}
