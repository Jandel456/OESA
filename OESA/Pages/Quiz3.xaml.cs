using System.ComponentModel;
using System.Globalization;
using Microsoft.Maui.Controls;
namespace OESA.Pages;

public partial class Quiz3 : ContentPage
{
    public List<QuestionItem> CurrentQuestion { get; set; }

    public Quiz3()
    {
        InitializeComponent();

        UserLabel.Text = $"Hi, {SessionManager.UserName}";

        CurrentQuestion = new List<QuestionItem>
        {


            /// I NEED TO MAKE MULTIPLE CHOICE CHECKABLE BOXES THING!
            new QuestionItem
            {
                QuestionText = "Which of the following are valid superglobals in PHP? (Select all that apply)",
                Options = new List<string> { "$_LOCAL", "$_SESSION", "$_GLOBALS", "$_COOKIE"},
                CorrectAnswer = "$_SESSION",
                SelectedAnswer = null
            },
            new QuestionItem
            {
                QuestionText = "What is the default max_execution_time (in seconds) for a PHP script?",
                Options = new List<string> { "True", "False"},
                CorrectAnswer = "True",
                SelectedAnswer = null
            },
            new QuestionItem
            {
                QuestionText = "PHP 7.0 was officially released on which date?",
                Options = new List<string> { "Ensure required values have been provided", "Check data is in a usable format/range", "All of the above", "It's best practice"},
                CorrectAnswer = "All of the above",
                SelectedAnswer = null
            },

            new QuestionItem
            {
                QuestionText = "Arrange the following steps in the correct order to process a form in PHP:",
                Options = new List<string> { "MIX HTML & PHP", "Make HTML", "Make PHP", "Huh?!"},
                CorrectAnswer = "MIX HTML & PHP",
                SelectedAnswer = null
            },

            new QuestionItem
            {
                QuestionText = "On a scale of 0 to 100, how would you rate your familiarity with PHP?",
                Options = new List<string> { "Boolean data type", "Compound data type", "Reference data type", "Primitive data type"},
                CorrectAnswer = "100",
                SliderValue = 0
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

            if (question.SliderValue.ToString() == question.CorrectAnswer)
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

    private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
    {
        if (sender is Slider slider)
        {
            var parentLayout = slider.Parent as VerticalStackLayout;

            var sliderValueLabel = parentLayout?.Children.OfType<Label>().FirstOrDefault();

            if (sliderValueLabel != null)
            {
                sliderValueLabel.Text = $"Value: {slider.Value:0}";
            }

            var questionItem = (slider.Parent?.Parent?.BindingContext as QuestionItem);
            if (questionItem != null)
            {
                questionItem.SliderValue = (int)slider.Value;
            }
        }
    }
}
