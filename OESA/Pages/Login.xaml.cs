using System.Text.RegularExpressions;

namespace OESA.Pages;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
        UserLabel.Text = $"Hi, {SessionManager.UserName}";

    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string storedEmail = SessionManager.Email;
        string storedPassword = SessionManager.Password;

        string email = EmailEntry.Text?.Trim();
        string password = PasswordEntry.Text;

        if (email == storedEmail && password == storedPassword)
        {
            await Shell.Current.GoToAsync("SelectQuiz");
        }
        else
        {
            MessageLabel.Text = "Invalid email or password.";
        }
    }

}