import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http'
import 'rxjs/add/operator/map'
import { UserInform } from '../models/userInform.model';


@Injectable()
export class ProfileService {
    readonly rootUrl = 'http://localhost:57609/api/users';
    obj;
    constructor(private http: HttpClient) { }

    getUser() {
        return this.http.get(this.rootUrl + '/getUser');
    }

    postFile(fileToUpload: File, userId: number) {
        const endpoint = this.rootUrl + '/addAvatar/'+userId;
        const formData: FormData = new FormData();
        formData.append('Image', fileToUpload, fileToUpload.name);
        return this.http.post(endpoint, formData);
    }

    editPersonalInfo(userInformNew: UserInform, userInformOld: UserInform, ) {
        const endpoint = this.rootUrl + '/edit/' + userInformOld.UserId;
        console.log(userInformOld.Email);
        console.log(userInformNew.Email);
        const formData: FormData = new FormData();
        const body: UserInform = {
            UserId: userInformOld.UserId,
            FirstName: (userInformNew.FirstName!=null && userInformNew.FirstName.length > 0) ? userInformNew.FirstName : userInformOld.FirstName,
            LastName: (userInformNew.LastName!=null &&userInformNew.LastName.length > 0) ? userInformNew.LastName : userInformOld.LastName,
            Email: userInformOld.Email,
            Birthday: userInformOld.Birthday,
            City: (userInformNew.City!=null && userInformNew.City.length > 0) ? userInformNew.City : userInformOld.City,
            Image: userInformOld.Image,
        }
        return this.http.put(endpoint, body);
    }

    
}