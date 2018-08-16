import { Component, HostBinding } from '@angular/core';
import { UserInform } from './models/userInform.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public authorizedUser: UserInform;
}
