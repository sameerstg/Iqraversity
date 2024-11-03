using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    public List<QuestionAnswer> questionAnswers = new();

}
[CreateAssetMenu(fileName = "NewQuestionAnswer", menuName = "Questions/QuestionAnswer")]
[System.Serializable]
public class QuestionAnswer:ScriptableObject
{

    public string question;
    public List<Answer> answers;

}

[System.Serializable]
public class Answer
{

    public string answer;
    public QuestionAnswer next;
}
