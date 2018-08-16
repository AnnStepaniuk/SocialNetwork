import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProfileService } from '../../services/profile.service';
import { UserInform } from '../../models/userInform.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  userInform: UserInform =null;
  imageUrl: any = "/assets/img/default-user.png";

  constructor(private router: Router, private profileService:ProfileService) { }

  ngOnInit() {
    this.profileService.getUser().subscribe((data: any) => {
      this.userInform = data;
      if (this.userInform.Image !== null && this.userInform.Image.length > 0) {
        this.imageUrl = 'http://localhost:57609/api/users/user/image/get?imageName=' + this.userInform.Image;
      }
    });
  }

  Logout() {
    localStorage.removeItem('userToken');
    this.router.navigate(['/login']);
  }
}
