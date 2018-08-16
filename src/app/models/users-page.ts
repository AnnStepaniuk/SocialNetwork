
import { UserInform } from './userInform.model';

export interface UsersPage {
  page:        number;
  per_page:    number;
  total:       number;
  total_pages: number;
  // data:        User[];
  data:        UserInform[];
}


