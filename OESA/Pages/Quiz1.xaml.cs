using Microsoft.Maui.Controls;
namespace OESA.Pages;

public partial class Quiz1 : ContentPage
{
    public List<QuestionItem> CurrentQuestion { get; set; }
    public string QuestionText { get; set; }
    public string Option1 { get; set; }
    public string Option2 { get; set; }
    public string Option3 { get; set; }
    public string Option4 { get; set; }

    public Command SubmitCommand { get; set; }

    public Quiz1()
    {
        InitializeComponent();

        CurrentQuestion = new List<QuestionItem>
        {
            new QuestionItem
            {
                QuestionText = "What is the capital of France?",
                Options = new List<string> { "Berlin", "Madrid", "Paris", "Rome" },
                CorrectAnswer = "Paris"
            },
            new QuestionItem
            {
                QuestionText = "Which planet is known as the Red Planet?",
                Options = new List<string> { "Earth", "Venus", "Mars", "Jupiter" },
                CorrectAnswer = "Mars"
            },
            new QuestionItem
            {
                QuestionText = "What is the largest ocean?",
                Options = new List<string> { "Atlantic", "Indian", "Arctic", "Pacific" },
                CorrectAnswer = "Pacific"
            }
        };

        SubmitCommand = new Command(OnSubmit);

        BindingContext = this;
    }

    public class QuestionItem
    {
        public required string QuestionText { get; set; }
        public required List<string> Options { get; set; }
        public required string CorrectAnswer { get; set; }
    }

    private void OnSubmit()
    {


    }
}