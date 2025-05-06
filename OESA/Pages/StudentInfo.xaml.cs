namespace OESA.Pages;
using System.Text.RegularExpressions;


public partial class StudentInfo : ContentPage
{
    public StudentInfo()
    {
        InitializeComponent();

        UserNameLabel.Text = SessionManager.UserName;
        FirstNameLabel.Text = SessionManager.FirstName;
        LastNameLabel.Text = SessionManager.LastName;
        EmailLabel.Text = SessionManager.Email;
        IDLabel.Text = SessionManager.ID.ToString();
    }
}
