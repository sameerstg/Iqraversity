using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewQuestionAnswer", menuName = "Questions/QuestionAnswer")]
public class QuestionAnswer : ScriptableObject
{

    [TextArea]
    public string question;
    public List<Answer> answers;
    public List<InputFieldForUser> inputFieldsForUser;
    public bool isProceedButton;

}

[System.Serializable]
public class Answer
{
    [TextArea]

    public string answer;
    public int next;

}
[System.Serializable]
public class InputFieldForUser
{
    public bool isMandatory;
    [TextArea]
    public string title;

    public int next;

}
[System.Serializable]
public class QuestionAnswerNew 
{

    [TextArea]
    public string question;
    public List<Answer> answers;
    public List<InputFieldForUser> inputFieldsForUser;
    public bool isProceedButton;

}
[System.Serializable]
public class AllQuestionAnswer
{
    public List<QuestionAnswerNew> questionsAndAnswers;
}