using System;
using System.Text.RegularExpressions;

namespace OESA.Pages;

public partial class SignUp : ContentPage
{
    public SignUp()
    {
        InitializeComponent();

        UserLabel.Text = $"Hi, {SessionManager.UserName}";
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        string firstName = FirstNameEntry.Text?.Trim();
        string lastName = LastNameEntry.Text?.Trim();
        string email = EmailEntry.Text?.Trim();
        string password = PasswordEntry.Text;
        string confirmPassword = ConfirmPasswordEntry.Text;

        List<string> errors = new();

        // First name validation
        if (string.IsNullOrWhiteSpace(firstName) || firstName.Length < 3 || Regex.IsMatch(firstName, @"[^a-zA-Z]"))
        {
            errors.Add("First name must be at least 3 letters and contain no special characters.");
        }

        // Last name validation (optional, but can add basic check)
        if (string.IsNullOrWhiteSpace(lastName))
        {
            errors.Add("Last name cannot be empty.");
        }

        // Email validation
        if (!Regex.IsMatch(email ?? "", @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            errors.Add("Invalid email format.");
        }

        // Password validation
        if (password.Length < 5)
        {
            errors.Add("Password must be at least 5 characters long.");
        }
        if (!Regex.IsMatch(password, @"[A-Z]"))
        {
            errors.Add("Password must contain at least one uppercase letter.");
        }
        if (!Regex.IsMatch(password, @"[\W_]"))
        {
            errors.Add("Password must contain at least one special character.");
        }

        // Confirm password validation
        if (password != confirmPassword)
        {
            errors.Add("Passwords do not match.");
        }

        // Display results
        if (errors.Any())
        {
            MessageLabel.TextColor = Colors.Red;
            MessageLabel.Text = string.Join("\n", errors);
        }
        else
        {

            MessageLabel.TextColor = Colors.Green;
            MessageLabel.Text = "Registration successful!";

            SessionManager.UserName = $"{firstName} {lastName}";
            SessionManager.FirstName = firstName;
            SessionManager.LastName = lastName;
            SessionManager.Email = email;
            SessionManager.Password = password;
            Random rnd = new Random();
            SessionManager.ID = rnd.Next(1000, 10000); ;


            await Task.Delay(1500); // 1.5 seconds
            await Navigation.PushAsync(new SelectQuiz());

        }
    }
}
