import { UserInform } from "./userInform.model";

export class ReceivedMessage
{   
    MessageId: number;
    Sender: UserInform;
    MessageText: string;
    MessageDate: Date
}