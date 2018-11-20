

export class LoginModel {
    public email: string;
    public password: string;
}

export class LoginResult {
    public isSuccess: boolean;
    public errorMessage: string;
    public jwtToken: string;
}

