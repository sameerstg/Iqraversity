using System;
using System.Collections.Generic;
using System.IO;
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
    //[SerializeField]
    //public QuestionAnswer firstQuestionAnswer;
    [SerializeField]
    public QuestionAnswerNew currentQuestionAnswer;
    public List<Action> actions = new();
    [SerializeField]
    public List<QuestionAnswerNew> questionsAndAnswers;
    public AllQuestionAnswer allQuestionAnswer;

    [ContextMenu("ASfasf")]
    public void VAl()
    {
        allQuestionAnswer.questionsAndAnswers = questionsAndAnswers;
        File.WriteAllText(Application.dataPath+ "\\_project\\Data.json",JsonUtility.ToJson(allQuestionAnswer));
    }
    private void OnEnable()
    {
        CloseCanvas();
    }
    void CloseCanvas()
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
        currentQuestionAnswer = questionsAndAnswers[0];
        ShowQuestionAnswer(currentQuestionAnswer);
    }
    public void ShowQuestionAnswer(QuestionAnswerNew newQA)
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
            int n = item.next;
            slots[curr++].ShowButton(item.answer, () => AnswerQuestion(n));
            actions.Add(() => AnswerQuestion(item.next));
        }
        foreach (var item in newQA.inputFieldsForUser)
        {
            int n = item.next;
            slots[curr++].ShowInputfield(item.title, () => AnswerQuestion(n));
            actions.Add(() => AnswerQuestion(item.next));
        }

    }
    public void AnswerQuestion(int next)
    {
        if (next == -1)
        {
            CloseCanvas();

            return;
        }
        ShowQuestionAnswer(questionsAndAnswers[next]);

    }
    public void AnswerQuestionMacro(int next)
    {

        actions[next]?.Invoke();
    }
    //public void AnswerQuestion(int index)
    //{
    //}
}


