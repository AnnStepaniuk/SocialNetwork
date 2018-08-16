import { UserInform } from "./userInform.model";

export class SentMessage
{   
    MessageId: number;
    Receiver: UserInform;
    MessageText: string;
    MessageDate: Date
}