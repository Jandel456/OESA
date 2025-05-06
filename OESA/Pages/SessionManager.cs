namespace OESA.Pages;

public class QuizAttempt
{
    public string QuizType { get; set; } = string.Empty;
    public int AttemptNumber { get; set; }
    public DateTime SubmissionTime { get; set; }
    public int Grade { get; set; }
    public int StudentID { get; set; }

}

public class SessionManager
{
    public static string UserName { get; set; } = string.Empty;
    public static string FirstName { get; set; } = string.Empty;
    public static string LastName { get; set; } = string.Empty;
    public static string Email { get; set; } = string.Empty;
    public static string Password { get; set; } = string.Empty;
    public static int ID { get; set; }

    public static string storedUserName { get; set; } = string.Empty;
    public static string storedFirstName { get; set; } = string.Empty;
    public static string storedLastName { get; set; } = string.Empty;
    public static string storedEmail { get; set; } = string.Empty;
    public static string storedPassword { get; set; } = string.Empty;
    public static int storedID { get; set; }


    public static List<QuizAttempt> QuizAttempts { get; set; } = new List<QuizAttempt>();


    public static void RecordQuizSubmission(string quizType, int score)
    {
        int attemptCount = QuizAttempts.Count(q => q.QuizType == quizType) + 1;

        var attempt = new QuizAttempt
        {
            QuizType = quizType,
            AttemptNumber = attemptCount,
            SubmissionTime = DateTime.Now,
            Grade = score,
            StudentID = ID
        };

        QuizAttempts.Add(attempt);
    }

}
