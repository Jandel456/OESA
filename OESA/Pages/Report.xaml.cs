using System.Collections.ObjectModel;

namespace OESA.Pages;

public class QuizAttemptViewModel
{
    private QuizAttempt _attempt;

    public QuizAttemptViewModel(QuizAttempt attempt)
    {
        _attempt = attempt;
    }

    public string QuizType => _attempt.QuizType;
    public string AttemptDisplay => $"Attempt #{_attempt.AttemptNumber}";
    public string SubmissionDisplay => $"Submitted: {_attempt.SubmissionTime:g}";
    public string GradeDisplay => $"Grade: {_attempt.Grade}";
    public string StudentIDDisplay => $"Student ID: {_attempt.StudentID}";

}

public partial class Report : ContentPage
{
    public ObservableCollection<QuizAttemptViewModel> quizReport { get; set; }

    public Report()
    {
        InitializeComponent();

        quizReport = new ObservableCollection<QuizAttemptViewModel>(
            SessionManager.QuizAttempts.Select(a => new QuizAttemptViewModel(a))
        );

        QuizHistoryCollection.ItemsSource = quizReport;
    }
}
