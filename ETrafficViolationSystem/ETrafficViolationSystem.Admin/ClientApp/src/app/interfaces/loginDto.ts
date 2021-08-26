export interface ILoginDto {
  token: string,
  expiration: string,
  refreshToken: string,
  refreshTokenExpiration: string
}
