namespace OESA.Pages;

public partial class Logout : ContentPage
{
    public Logout()
    {
        InitializeComponent();


        SessionManager.storedEmail = SessionManager.Email;
        SessionManager.storedPassword = SessionManager.Password;
        SessionManager.storedID = SessionManager.ID;
        SessionManager.storedUserName = SessionManager.UserName;
        SessionManager.storedFirstName = SessionManager.FirstName;
        SessionManager.storedLastName = SessionManager.LastName;

        SessionManager.Email = string.Empty;
        SessionManager.Password = string.Empty;
        SessionManager.ID = 0;
        SessionManager.UserName = string.Empty;
        SessionManager.FirstName = string.Empty;
        SessionManager.LastName = string.Empty;
        UserLabel.Text = $"Hi, {SessionManager.UserName}";
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await PerformLogoutAsync();
    }

    private async Task PerformLogoutAsync()
    {
        await Shell.Current.GoToAsync("Login");             /// broken
    }
}   
