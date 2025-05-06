namespace OESA.Pages;

public partial class Homepage : ContentPage
{
	public Homepage()
	{
		InitializeComponent();

        UserLabel.Text = $"Hi, {SessionManager.UserName}";


        DateLabel.Text = $"Today's date: {DateTime.Now.ToString("MMMM dd, yyyy")}";

        InspirationalQuote.Text = "First, solve the problem. Then, write the code";

        Credits.Text = "Developed By: Aiden Longueville | David McGregor | Michael Roberts";

    }

    private async void GoToLogin(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Login());
    }

    private async void GoToSignUp(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SignUp());
    }

}