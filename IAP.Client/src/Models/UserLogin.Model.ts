export class UserLoginModel
{
    constructor(private login: string, private password: string)
    {
        this.Login = login;
        this.Password = password;
    }
    Login = "";
    Password = "";
}