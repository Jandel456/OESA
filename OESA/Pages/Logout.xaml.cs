namespace OESA.Pages;

public partial class Logout : ContentPage
{
    public Logout()
    {
        InitializeComponent();
        UserLabel.Text = $"Hi, {SessionManager.UserName}";
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await PerformLogoutAsync();
    }

    private async Task PerformLogoutAsync()
    {
        SessionManager.Email = string.Empty;
        SessionManager.Password = string.Empty;

        await Shell.Current.GoToAsync("login");
    }
}   
