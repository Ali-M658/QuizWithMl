using System;

using System.Collections.Generic;
using QuizWithMl.GameArea;
public class QuestionBank
{
    private Dictionary<int, List<Question>> questionDict;
    private Question[] QList;
    public QuestionBank(params Question[] questionlist)
    {
        QList = questionlist;
        questionDict = new Dictionary<int, List<Question>>()
        {
            { 0, new List<Question>() },
            { 1, new List<Question>() },
            { 2, new List<Question>() },
            { 3, new List<Question>() },
            { 4, new List<Question>() },
            { 5, new List<Question>() },
            { 6, new List<Question>() }
        };
        sortByDifficulty();
    } 
 
    private void sortByDifficulty()
    {
        foreach (Question question in QList)
        {
            int difficulty = question.Difficulty;
            questionDict[difficulty].Add(question);
        }
    }
    public List<Question> QuestionByDiff(int difficulty)
    {
        return questionDict.ContainsKey(difficulty) ? questionDict[difficulty] : new List<Question>();
    }
}