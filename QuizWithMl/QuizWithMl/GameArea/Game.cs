using System.Data;

namespace QuizWithMl.GameArea;

public class Game
    {
        private static int streakCounter = 0;
        private int questionCounter = 0;
        private int maxStreak = 0;
        private int correctAnswer = 0;
        private int maxStreakPos = 10;
        private Player player;
        private QuestionBank bank;

        public Game()
        {
            player = new Player();
            QuestionGen gen = new QuestionGen();
            bank = new QuestionBank(gen.Questions);
        }

        public void GamePlay()
        {
            Console.WriteLine("Welcome to the quiz game! You will answer 10 questions at a time, \n" +
                              "and the model will evaluate your score to see if you're ready \n" +
                              "to move on to the next difficulty level. Good luck! \n" + 
                              " (decimal anwsers to 2nd place accuracy and rounded)");

            while (true)
            {
                for (int i = 1; i <= 6; i++)
                {
                    List<Question> questions = bank.QuestionByDiff(i);

                    foreach (Question quest in questions)
                    {
                        questionCounter++;
                        Console.WriteLine(questionCounter + ". " + quest.question);

                        string answer = Console.ReadLine();
                        if (quest.IsCorrect(answer))
                        {
                            Console.WriteLine("The answer is correct!");
                            streakCounter++;
                            correctAnswer++;
                            player.IncrementCorrectAnswers();
                        }
                        else
                        {
                            Console.WriteLine("The answer is incorrect.");
                            player.IncrementWrongAnswers();
                            streakCounter = 0;
                        }

                        if (streakCounter > maxStreak)
                        {
                            maxStreak = streakCounter;
                        }

                        if (questionCounter % 10 == 0)
                        {
                            if (Evaluate(i))
                            {
                                Console.WriteLine($"You passed difficulty level {i}! Next Level...");
                            }
                            else
                            {
                                Console.WriteLine($"You failed... ");
                                break;
                            }
                        }
                    }
                }
            }
        }

        private bool Evaluate(int difficultyLevel)
        {
            Console.WriteLine("Evaluating whether you can pass or not...");
            MlClassification classification = new MlClassification(maxStreak, 10 * difficultyLevel, correctAnswer);
            float score = classification.calculateScore(correctAnswer,maxStreakPos*difficultyLevel, maxStreak,maxStreakPos);
            if (classification.shouldLevelUp(score))
            {
                return true;
            }
            maxStreak = 0;
            streakCounter = 0;
            return false;
        }

        public static void Main(string[] args)
        {
            Game game = new Game();
            game.GamePlay();
        }
    }