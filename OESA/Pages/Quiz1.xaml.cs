using System.Globalization;
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
                CorrectAnswer = "Paris",
            },
            new QuestionItem
            {
                QuestionText = "Which planet is known as the Red Planet?",
                Options = new List<string> { "Earth", "Venus", "Mars", "Jupiter" },
                CorrectAnswer = "Mars",
            },
            new QuestionItem
            {
                QuestionText = "What is the largest ocean?",
                Options = new List<string> { "Atlantic", "Indian", "Arctic", "Pacific" },
                CorrectAnswer = "Pacific",
            }
        };

        BindingContext = this;
    }

    public class QuestionItem
    {
        public required string QuestionText { get; set; }
        public required List<string> Options { get; set; }
        public required string CorrectAnswer { get; set; }
        public string? SelectedAnswer { get; set; }  // we make this optional now, so we can give an error message to force the user to select an answer later

        public QuestionItem()
        {
            SelectedAnswer = null;  // Ensures SelectedAnswer starts as null
        }
    }

    private async void OnSubmit(object sender, EventArgs e)
    {
        int score = 0;

        List<string> unansweredQuestions = new List<string>();


        for (int i = 0; i < CurrentQuestion.Count; i++)
        {
            var question = CurrentQuestion[i];

            if (string.IsNullOrEmpty(question.SelectedAnswer))
            {
                unansweredQuestions.Add($"Question {i + 1}: {question.QuestionText}");
            }

            if (question.SelectedAnswer == question.CorrectAnswer)
            {
                score++;
            }
        }

        if (unansweredQuestions.Any())
        {
            foreach (var unanswered in unansweredQuestions)
            {
                await DisplayAlert("Error", $"Select an answer for {unanswered}", "OK");
            }
            return;
        }

        await DisplayAlert("Quiz Result", $"You scored {score} out of {CurrentQuestion.Count}", "OK");
    }
}