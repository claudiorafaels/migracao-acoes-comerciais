using System;

public class Token
{
    public string Scope { get; set; }
    public string TokenType { get; set; }
    public string ExpiresIn { get; set; }
    public string RefreshToken { get; set; }
    public string AccessToken { get; set; }
}