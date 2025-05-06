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
        string email = EmailEntry.Text?.Trim();
        string password = PasswordEntry.Text;

        if (email == SessionManager.storedEmail && password == SessionManager.storedPassword)
        {

            SessionManager.Email = SessionManager.storedEmail;
            SessionManager.Password = SessionManager.storedPassword;
            SessionManager.ID = SessionManager.storedID;
            SessionManager.UserName = SessionManager.storedUserName;
            SessionManager.FirstName = SessionManager.storedFirstName;
            SessionManager.LastName = SessionManager.storedLastName;

            await Shell.Current.GoToAsync("SelectQuiz");
        }
        else
        {
            MessageLabel.Text = "Invalid email or password.";
        }
    }

}