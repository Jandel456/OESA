using System.ComponentModel;
using System.Globalization;
using Microsoft.Maui.Controls;
namespace OESA.Pages;

public partial class Quiz1 : ContentPage
{
    public List<QuestionItem> CurrentQuestion { get; set; }

    public Quiz1()
    {
        InitializeComponent();

        UserLabel.Text = $"Hi, {SessionManager.UserName}";


        CurrentQuestion = new List<QuestionItem>
        {
            new QuestionItem
            {
                QuestionText = "What must you do when a browser sends data?",
                Options = new List<string> { "Collect", "Validate", "Check for processing", "Escape or sanitize data", "All of the above"},
                CorrectAnswer = "All of the above",
                SelectedAnswer = null
            },
            new QuestionItem
            {
                QuestionText = "The input element is the most important form element and can be displayed in several ways, depending on the type attribute.",
                Options = new List<string> { "True", "False"},
                CorrectAnswer = "True",
                SelectedAnswer = null
            },
            new QuestionItem
            {
                QuestionText = "Why should data be validated when it is collected?",
                Options = new List<string> { "Ensure required values have been provided", "Check data is in a usable format/range", "All of the above", "It's best practice"},
                CorrectAnswer = "All of the above",
                SelectedAnswer = null
            },

            new QuestionItem
            {
                QuestionText = "What does a php page do?",
                Options = new List<string> { "MIX HTML & PHP", "Make HTML", "Make PHP", "Huh?!"},
                CorrectAnswer = "MIX HTML & PHP",
                SelectedAnswer = null
            },

            new QuestionItem
            {
                QuestionText = "What kind of data type is an array?",
                Options = new List<string> { "Boolean data type", "Compound data type", "Reference data type", "Primitive data type"},
                CorrectAnswer = "Compound data type",
                SelectedAnswer = null
            }
        };

        BindingContext = this;
    }

    private async void OnSubmit(object sender, EventArgs e)
    {
        int score = 0;

        List<string> unansweredQuestions = new List<string>();


        for (int i = 0; i < CurrentQuestion.Count; i++)
        {
            var question = CurrentQuestion[i];

            System.Diagnostics.Debug.WriteLine($"Question {i + 1}: '{question.QuestionText}' - SelectedAnswer: '{question.SelectedAnswer}'");


            if (string.IsNullOrEmpty(question.SelectedAnswer))
            {
                unansweredQuestions.Add($"Question {i + 1}: {question.QuestionText}");
            }

            if (question.SelectedAnswer == question.CorrectAnswer)
            {
                score++;
            }
        }

        if (unansweredQuestions.Count > 0)
        {
            foreach (var unanswered in unansweredQuestions)
            {
                await DisplayAlert("Error", $"Select an answer for {unanswered}", "OK");
            }
            return;
        }

        await DisplayAlert("Quiz Result", $"You scored {score} out of {CurrentQuestion.Count}", "OK");

        // this records that grades and sends it to the report.
        int quizquestionCount = CurrentQuestion.Count;
        int quizScore = (int)(((double)score / quizquestionCount) * 100);
        SessionManager.RecordQuizSubmission("Quiz1", quizScore);


        DateTime submissionTime = DateTime.Now;
        await Task.Delay(1500);
        await Navigation.PushAsync(new Quiz1Results(CurrentQuestion, score, submissionTime));

    }

    private void OnRadioCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (sender is RadioButton rb && e.Value)
        {
            var selectedOption = rb.Content?.ToString();
            var questionItem = (rb?.Parent?.Parent?.BindingContext as QuestionItem);

            if (questionItem != null)
            {
                questionItem.SelectedAnswer = selectedOption;
                System.Diagnostics.Debug.WriteLine($"Selected '{selectedOption}' for '{questionItem.QuestionText}'");
            }
        }
    }
}