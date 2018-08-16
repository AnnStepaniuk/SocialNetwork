import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UserInform } from '../../models/userInform.model';
import { DomSanitizer } from '@angular/platform-browser';
import { ProfileService } from '../../services/profile.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  authorizedUser: UserInform;
  imageUrl: any = "/assets/img/default-user.png";
  fileToUpload: File = null;
  userInform: UserInform;

  constructor(private profileService: ProfileService, private sanitizer: DomSanitizer) { }

  ngOnInit() {
    this.profileService.getUser().subscribe((data: any) => {
      this.authorizedUser = data;
      if (this.authorizedUser.Image !== null && this.authorizedUser.Image.length > 0) {
        this.imageUrl = 'http://localhost:57609/api/users/user/image/get?imageName=' + this.authorizedUser.Image;
      }
    });
  }

  handleFileInput(file: FileList) {
    this.fileToUpload = file.item(0);
    //Show image preview
    var reader = new FileReader();
    reader.onload = (event: any) => {
      this.imageUrl = event.target.result;
    };
    reader.readAsDataURL(this.fileToUpload);
  }

  OnEditSubmit(form: NgForm, userId: number ) {
    if (this.fileToUpload !== null) {
      this.profileService.postFile(this.fileToUpload, userId).subscribe();
    }
    this.profileService.editPersonalInfo(form.value, this.authorizedUser).subscribe();
  }

}
