using System.Collections;
using System.Collections.Generic;

public class Question
{
    public string question;
    public List<string> answers;
    public int correctAnswerIndex;

    public Question(string q, List<string> a, int index)
    {
        question = q;
        answers = a;
        correctAnswerIndex = index;
    }

    public void SetQuestion(string que)
    {
        question = que;
    }

    public string GetQuestion()
    {
        return question;
    }

    public void SetAnswer(int index, string value)
    {
        answers[index] = value;
    }

    public string GetAnswer(int index)
    {
        return answers[index];
    }

    public void SetCorrectAnswerIndex(int index)
    {
        correctAnswerIndex = index;
    }

    public int GetCorrectAnswerIndex()
    {
        return correctAnswerIndex;
    }
}
