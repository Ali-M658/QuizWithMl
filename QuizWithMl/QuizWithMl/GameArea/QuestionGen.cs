using QuizWithMl.GameArea;
using System;

public class QuestionGen
{
    public Question[] Questions { get; set; }

    public QuestionGen()
    {
        Questions = new Question[60];
        
        int questionIndex = 0;
        
        for (int i = 1; i <= 6; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Questions[questionIndex++] = GenerateQuestion(i);
            }
        }
    }
    
    public Question GenerateQuestion(int difficulty)
    {
        string questionText = "";
        string answerText = "";
        Random rand = new Random();
        double answer = 0;

        int num1, num2, num3, num4, operation, baseNum, c, lowerLimit, upperLimit;
        double areaUnderCurve;

        switch (difficulty)
        {
            case 1: 
                num1 = rand.Next(1, 21);
                num2 = rand.Next(1, 21);
                num3 = rand.Next(1, 21);
                num4 = rand.Next(1, 21);
                operation = rand.Next(1, 4); 

                if (operation == 1)
                {
                    answer = num1 + num2;
                    questionText = $"What is {num1} + {num2}?";
                }
                else if (operation == 2)
                {
                    answer = num1 - num2;
                    questionText = $"What is {num1} - {num2}?";
                }
                else
                {
                    answer = num1 * num2;
                    questionText = $"What is {num1} * {num2}?";
                }
                break;

            case 2: // Medium questions (square roots and basic operations)
                num1 = rand.Next(1, 21);
                answer = Math.Sqrt(num1);
                questionText = $"What is the square root of {num1}?";
                break;

            case 3: // Hard questions (logarithms with different bases)
                num1 = rand.Next(1, 11);
                baseNum = rand.Next(2, 5); // Bases 2, 3, 4
                answer = Math.Log(num1, baseNum);
                questionText = $"What is log base {baseNum} of {num1}?";
                break;

            case 4: // Very Hard questions (slope at a certain point - derivative)
                num1 = rand.Next(1, 11); 
                num2 = rand.Next(2, 6);  
                
                double xValue = rand.Next(0, 6);
                double slope = num1 * Math.Pow(num2, xValue) * Math.Log(num2,Math.E); // derivative at x = 3

                questionText = $"The equation of the power function is y = {num1}({num2})^x. What is the slope at x = 3?";
                answer = slope; // The slope at x = 3 is given by the derivative at that point
                break;


            case 5: // Extreme questions (Area under the curve, integral)
               num1=rand.Next(1, 11);
                num2=rand.Next(1, 11);
                num3=rand.Next(1, 11);
                num4 = rand.Next(1, 11);
                lowerLimit = 0;
                upperLimit = rand.Next(5, 11); // Random upper limit for the integral

                answer = (num1 / 4.0) * Math.Pow(upperLimit, 4) + (num2 / 3.0) * Math.Pow(upperLimit, 3) +
                         (num3 / 2.0) * Math.Pow(upperLimit, 2) + num4 * upperLimit;
                questionText = $"What is the area under the curve of the function y = {num1}x^3 + {num2}x^2 + {num3}x + {num4} from x = 0 to x = {upperLimit}?";
                break;

            case 6: // Extreme questions (Complex functions or advanced calculus)
                num1 = rand.Next(-10, 11); // lower limit
                num2 = rand.Next(-10, 11); // upper limit

                lowerLimit = Math.Min(num1, num2);
                upperLimit = Math.Max(num1, num2);

                 areaUnderCurve = (-upperLimit * Math.Cos(upperLimit) + Math.Sin(upperLimit)) - 
                                        (-lowerLimit * Math.Cos(lowerLimit) + Math.Sin(lowerLimit));

                questionText = $"What is the area under the curve of y = x * sin(x) from x = {lowerLimit} to x = {upperLimit}?";
                answer = areaUnderCurve;
                break;

        }

        answerText = Math.Round(answer, 2).ToString();

        return new Question(questionText, answerText, difficulty);
    }
}

