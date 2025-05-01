namespace OESA.Pages;

    public class QuestionItem
    {
        public string QuestionText { get; set; }
        public List<string> Options { get; set; }
        public string CorrectAnswer { get; set; }
        public string? SelectedAnswer { get; set; }
    }
