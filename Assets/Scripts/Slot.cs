using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{

    [Header("Button Slot Items")]
    public Button button;
    public TextMeshProUGUI buttonTitle;
    [Header("Input Field")]
    public TMP_InputField inputField;

    public void ResetSlot()
    {
        gameObject.SetActive(false);
        button.onClick.RemoveAllListeners();
        inputField.onSubmit.RemoveAllListeners();
        button.gameObject.SetActive(false);
        inputField.gameObject.SetActive(false);
    }
    public void ShowButton(string title, Action onClick)
    {
        gameObject.SetActive(true);
        button.gameObject.SetActive(true);
        buttonTitle.text = title;
        button.onClick.AddListener(() => { onClick?.Invoke(); });
    }
    public void ShowInputfield(string placeholder, Action onSubmit)
    {
        gameObject.SetActive(true);
        inputField.gameObject.SetActive(true);
        inputField.placeholder.GetComponent<TextMeshProUGUI>().text = placeholder;
        inputField.onSubmit.AddListener((x) => { onSubmit?.Invoke(); });
    }
}
