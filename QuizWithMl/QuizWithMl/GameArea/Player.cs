namespace QuizWithMl.GameArea;

public class Player
{
     
    int CorrectAnswers{ get; set; } 
    int TotalQuestions{get; set;}
    
    int Streak { get; set; }
    public Player()
    {
        CorrectAnswers = 0;
        TotalQuestions = 0;
    }

    public void IncrementCorrectAnswers()
    {
        CorrectAnswers++;
        TotalQuestions++;
    }

    public void IncrementWrongAnswers()
    {
        TotalQuestions++;
    }
}