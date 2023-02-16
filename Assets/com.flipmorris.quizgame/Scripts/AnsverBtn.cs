using System;
using UnityEngine.UI;
using UnityEngine;

public class AnsverBtn : MonoBehaviour
{
    private Text QuestionText { get; set; }

    public static Action<int> OnAnsverSelected { get; set; }

    private void Awake()
    {
        QuestionText = GetComponentInChildren<Text>();
        GameModule.OnQuestionUpdated += (question) =>
        {
            string body = transform.GetSiblingIndex() switch
            {
                0 => $"A. {question.a}",
                1 => $"B. {question.b}",
                2 => $"C. {question.c}",
                3 => $"D. {question.d}"
            };

            QuestionText.text = $"{body}";
        };
    }

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            OnAnsverSelected?.Invoke(transform.GetSiblingIndex());
        });
    }
}
