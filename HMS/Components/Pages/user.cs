

public class c_user{
    public string s_email { get; set; }
    public string s_password { get; set; }
    public bool b_isLoggedIn { get; set; } = false;

    public void SetUser(string email, string password)
    {
        s_email = email;
        s_password = password;
        b_isLoggedIn = true;
    }

    public void ClearUser()
    {
        s_email = string.Empty;
        s_password = string.Empty;
        b_isLoggedIn = false;
    }
}