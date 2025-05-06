using System.Windows.Input;

namespace OESA.Pages;

public partial class SelectQuiz : ContentPage
{
    public List<ButtonItem> QuizList { get; set; }
    public SelectQuiz()
	{
		InitializeComponent();

        UserLabel.Text = $"Hi, {SessionManager.UserName}";

        QuizList = new List<ButtonItem>
        {
            new ButtonItem { Title = "Quiz 1: General PHP Knowledge", Description = "Test your knowledge in PHP practices", QuizLocation = new Command(GotoQuiz1) },
            new ButtonItem { Title = "Quiz 2: PHP Data Types & Arrays", Description = "Test your knowledge in data types and arrays", QuizLocation = new Command(GotoQuiz2) },
            new ButtonItem { Title = "Quiz 3: PHP & Web Development", Description = "Capstone Quiz", QuizLocation = new Command(GotoQuiz3) }
        };

        BindingContext = this; // This connects XAML to the data, very odd process?

    }
    public class ButtonItem
    {
        public required string Title { get; set; }      //Title is required
        public string? Description { get; set; }        // Description is optional, actually kinda cool syntax notation
        public required ICommand QuizLocation { get; set; }

    }

    private async void GotoQuiz1()
    {
        await Navigation.PushAsync(new Quiz1());
    }

    private async void GotoQuiz2()
    {
        await Navigation.PushAsync(new Quiz2());
    }
   private async void GotoQuiz3()
    {
        await Navigation.PushAsync(new Quiz3());
    }
}