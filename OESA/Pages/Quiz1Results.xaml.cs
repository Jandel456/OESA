namespace OESA.Pages;

/// <summary>
/// INITALLY THIS WAS MEANT TO BE MADE FOR EACH AND EVERY QUIZ, BUT ITS ACTUALLY FLEXIBLE ENOUGH TO BE CALLED BY EVERY SINGLE QUIZ, PRETTY COOL!
/// </summary>
public class QuestionReviewItem
{
    public string QuestionText { get; set; }
    public string StudentAnswer { get; set; }
    public string CorrectAnswer { get; set; }

    public string StudentAnswerDisplay => $"Your Answer: {StudentAnswer}";
    public string CorrectAnswerDisplay => $"Correct Answer: {CorrectAnswer}";
}

public partial class Quiz1Results : ContentPage
{
    public string StudentInfo { get; set; }
    public string ScoreSummary { get; set; }
    public string SubmissionTimeDisplay { get; set; }
    public List<QuestionReviewItem> QuestionReviews { get; set; }

    public Quiz1Results(List<QuestionItem> questions, int score, DateTime submissionTime)
    {
        InitializeComponent();

        int correct = score;
        int total = questions.Count;
        int incorrect = total - correct;
        int percent = (int)(((double)score / total) * 100);

        StudentInfo = $"Student: {SessionManager.UserName}\nEmail: {SessionManager.Email}\nID: {SessionManager.ID}";
        ScoreSummary = $"Score: {percent}% ({correct} correct, {incorrect} wrong)";
        SubmissionTimeDisplay = $"Submitted on: {submissionTime:g}";

        QuestionReviews = questions.Select(q => new QuestionReviewItem
        {
            QuestionText = q.QuestionText,
            StudentAnswer = q.SelectedAnswer,
            CorrectAnswer = q.CorrectAnswer
        }).ToList();

        BindingContext = this;
    }
}
