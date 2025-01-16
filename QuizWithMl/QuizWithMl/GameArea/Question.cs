namespace QuizWithMl.GameArea;

public class Question
{   
    public string question { get; set; }
    public string answer { get; set; }

    /// <summary>
    /// Difficulty of the question 1-6, 1 is easy, 6 is extreme
    /// 
    /// </summary>
    public int Difficulty { get; set; }

    public Question(string question, string answer, int difficulty)
    {
        this.question = question;
        this.answer = answer;
        this.Difficulty = difficulty;
    }
    public bool IsCorrect(string answer)
    {
        return this.answer == answer;
    }
}