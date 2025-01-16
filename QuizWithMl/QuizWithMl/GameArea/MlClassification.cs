
namespace QuizWithMl.GameArea;
 
public class MlClassification
{
    private int streak;
    private int total;
    private int correct;
    public MlClassification(int streak, int total, int correct)
    {
        this.streak = streak;
        this.total = total;
        this.correct = correct;
    }

    private double logisticFunction(double x, double k = 0, double x0 = 0)
    {
        return 1 / (1 + Math.Exp(-k * (x - x0)));
    }

    public float calculateScore(int correctQ, int totalQ, int maxStreak, int maxStreakPossible)
    {
        float correctScore = correctQ/totalQ;
        
        float streakScore = maxStreak/maxStreakPossible;
        //0.6 and 0.4 are adjustable weights
        float score = correctScore * streakScore * 0.6f + streakScore * 0.4f;

        return score;
    }
    public bool shouldLevelUp(float score, double threshold= 0.5)
    {
        /**
         * Logistic function to see if player level up.
         **/
        double levelUpProb = logisticFunction(score);
        if (levelUpProb > threshold)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}