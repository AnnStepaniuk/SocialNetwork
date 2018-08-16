import { Component, OnInit } from '@angular/core';
import { FriendsService } from '../../services/friends.service';
import { ProfileService } from '../../services/profile.service';
import { UserInform } from '../../models/userInform.model';
import { ReceivedMessage } from '../../models/receivedMessage.model';
import { SentMessage } from '../../models/sentMessage.model';
import * as $ from 'jquery'
import { Message } from '../../models/message.model';

@Component({
  selector: 'app-message',
  templateUrl: './message.component.html',
  styleUrls: ['./message.component.css']
})
export class MessageComponent implements OnInit {
  userId: number;
  nameFriend: string;
  idFriend: number;
  imageUrl: any = "/assets/img/default-user.png";
  receivedMessages: ReceivedMessage[] = [];
  sentMessages: SentMessage[] = []

  constructor(private friendsService: FriendsService, private profileService: ProfileService) { }

  ngOnInit() {
    this.profileService.getUser().subscribe(
      (data: UserInform) => {
        this.userId = data.UserId;
        this.friendsService.getReceivedMessages(this.userId).subscribe((data: any) => {
          this.receivedMessages.push(...data);
          $('#viewReceived').hide();
          if (this.receivedMessages == []) {
            $('#noReceived').hide();
          }
          else {
            $('#noReceived').show();
          }
        });
      });
  }


  clickReply(friend: UserInform) {
    this.nameFriend = friend.FirstName + ' ' + friend.LastName;
    this.idFriend = friend.UserId;
  }

  ClickOnViewReceived() {
    this.receivedMessages = [];
    this.sentMessages = [];
    this.friendsService.getReceivedMessages(this.userId).subscribe((data: any) => {
      this.receivedMessages.push(...data);
      if (this.receivedMessages == []) {
        $('#noReceived').hide();
      }
      else {
        $('#noReceived').show();
      }
    });
    $('#viewSent').show();
    $('#viewReceived').hide();
    $("#messageHeader").text("Received messages");

  }

  ClickOnViewSent() {
    this.sentMessages = [];
    this.receivedMessages = [];
    this.friendsService.getSentMessages(this.userId).subscribe((data: any) => {
      this.sentMessages.push(...data);
    });
    $('#viewSent').hide();
    $('#viewReceived').show();
    $("#messageHeader").text("Sent messages");
    $('#noReceived').hide();
  }

  OnSendMessage(messageText: string) {
    console.log('onSend');
    var message: Message = {
      SenderId: this.userId,
      ReceiverId: this.idFriend,
      MessageText: messageText,
      MessageDate: new Date()
    };
    this.friendsService.sendMessage(message).subscribe(
    );
    $('#close').click();
    $('#successButton').click();

  }


  deleteMessage(message: SentMessage) {
    this.friendsService.deleteMessage(message.MessageId).subscribe(
      data => {
        var idx = this.sentMessages.indexOf(message);
        this.sentMessages.splice(idx, 1);
      }
    )
  }
}
