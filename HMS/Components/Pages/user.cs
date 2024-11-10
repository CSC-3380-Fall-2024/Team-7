

public class c_user{
    public string Email { get; set; }
    public string Password { get; set; }
    public bool IsLoggedIn { get; set; } = false;

    public void SetUser(string email, string password)
    {
        Email = email;
        Password = password;
        IsLoggedIn = true;
    }

    public void ClearUser()
    {
        Email = string.Empty;
        Password = string.Empty;
        IsLoggedIn = false;
    }
}