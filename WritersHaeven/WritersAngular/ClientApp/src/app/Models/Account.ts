import { IAccount } from "./iaccount";

export class Account implements IAccount {
    Username: string;
  Password: string;

  constructor(Username : string, Password: string ) {
    this.Username = Username; this.Password = Password;
  }


}
