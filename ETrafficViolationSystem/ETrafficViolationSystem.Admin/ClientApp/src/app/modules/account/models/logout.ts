export class LogoutRequest {
  token: string;

  constructor(token: string) {
    this.token = token;
  }
}
