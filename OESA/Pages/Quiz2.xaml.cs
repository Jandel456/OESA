using System.ComponentModel;
using System.Globalization;
using Microsoft.Maui.Controls;
namespace OESA.Pages;

public partial class Quiz2 : ContentPage
{
    public List<QuestionItem> CurrentQuestion { get; set; }

    public Quiz2()
    {
        InitializeComponent();

        UserLabel.Text = $"Hi, {SessionManager.UserName}";

        CurrentQuestion = new List<QuestionItem>
        {
            new QuestionItem
            {
                QuestionText = "An associative array uses a key to represent each value that it stores",
                Options = new List<string> {"True", "False"},
                CorrectAnswer = "True",
                SelectedAnswer = null
            },
            new QuestionItem
            {
                QuestionText = "Variables can hold arrays, which are a series of related values.",
                Options = new List<string> {"True", "False"},
                CorrectAnswer = "True",
                SelectedAnswer = null
            },
            new QuestionItem
            {
                QuestionText = "The array is a data type known as a compound data type.",
                Options = new List<string> {"True", "False"},
                CorrectAnswer = "True",
                SelectedAnswer = null
            },

            new QuestionItem
            {
                QuestionText = "PHP distinguishes between strings, numbers, and true or false values known as booleans",
                Options = new List<string> {"True", "False"},
                CorrectAnswer = "True",
                SelectedAnswer = null
            },

            new QuestionItem
            {
                QuestionText = "Variables store data that can change (or vary) each time a PHP page is used.",
                Options = new List<string> {"True", "False"},
                CorrectAnswer = "True",
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

        int quizquestionCount = CurrentQuestion.Count;
        int quizScore = (int)(((double)score / quizquestionCount) * 100);
        SessionManager.RecordQuizSubmission("Quiz1", quizScore);

        DateTime submissionTime = DateTime.Now;
        await Task.Delay(1500);
        await Navigation.PushAsync(new Quiz1Results(CurrentQuestion, score, submissionTime));

    }

    // this makes me want to claw my eyes out.
    //this is needed to make sure that when you press submit, and then change your answers later, you actually compare the selected questions with the correct answer.
    private void OnRadioCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (sender is RadioButton rb && e.Value)
        {
            var selectedOption = rb.Content?.ToString();
            var questionItem = (rb?.Parent?.Parent?.BindingContext as QuestionItem); // May vary depending on layout

            if (questionItem != null)
            {
                questionItem.SelectedAnswer = selectedOption;
                System.Diagnostics.Debug.WriteLine($"Selected '{selectedOption}' for '{questionItem.QuestionText}'");
            }
        }
    }

}