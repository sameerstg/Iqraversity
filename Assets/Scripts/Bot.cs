using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bot : MonoBehaviour
{
    [Header("Ui")]
    public GameObject canvas;
    public TextMeshProUGUI question;
    public List<Slot> slots;
    public Button proceedButton;

    public QuestionAnswer firstQuestionAnswer;
    public QuestionAnswer currentQuestionAnswer;
    public List<Action> actions = new();

    private void OnEnable()
    {
        canvas.SetActive(false);
        proceedButton.gameObject.SetActive(false);
        question.text = "";
        foreach (Slot slot in slots)
        {
            slot.gameObject.SetActive(false);
        }
    }
    public void OnClick()
    {
        currentQuestionAnswer = firstQuestionAnswer;
        ShowQuestionAnswer(currentQuestionAnswer);
    }
    public void ShowQuestionAnswer(QuestionAnswer newQA)
    {
        canvas.SetActive(true);
        question.text = newQA.question;
        int count = newQA.answers.Count + newQA.inputFieldsForUser.Count;
        int curr = 0;
        foreach (var item in slots)
        {
            item.ResetSlot();
        }
        actions = new();
        if (newQA == null)
        {
            canvas.gameObject.SetActive(false);
            return;
        }
        foreach (var item in newQA.answers)
        {
            slots[curr++].ShowButton(item.answer, () => AnswerQuestion(item.next));
            actions.Add(()=>AnswerQuestion(item.next));
        }
        foreach (var item in newQA.inputFieldsForUser)
        {
            slots[curr++].ShowInputfield(item.title, () => AnswerQuestion(item.next));
            actions.Add(()=>AnswerQuestion(item.next));
        }

    }
    public void AnswerQuestion(QuestionAnswer qa)
    {
        ShowQuestionAnswer(qa);
        
    }
    public void AnswerQuestion(int index)
    {
        actions[index]?.Invoke();
    }
}
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
    public QuestionAnswer next;

}
[System.Serializable]
public class InputFieldForUser
{
    public bool isMandatory;
    [TextArea]
    public string title;

    public QuestionAnswer next;

}
