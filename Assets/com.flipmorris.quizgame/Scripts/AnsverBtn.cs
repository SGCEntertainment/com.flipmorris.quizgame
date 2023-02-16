using System;
using UnityEngine.UI;
using UnityEngine;

public class AnsverBtn : MonoBehaviour
{
    private string AnsverString { get; set; }
    private Text QuestionText { get; set; }

    public static Action<string> OnAnsverSelected { get; set; }

    private void Awake()
    {
        QuestionText = GetComponentInChildren<Text>();
        GameModule.OnQuestionUpdated += (question) =>
        {
            int index = transform.GetSiblingIndex();

            AnsverString = index switch
            {
                0 => question.a,
                1 => question.b,
                2 => question.c,
                3 => question.d
            };

            string finalBody = index switch
            {
                0 => $"A. {AnsverString}",
                1 => $"B. {AnsverString}",
                2 => $"C. {AnsverString}",
                3 => $"D. {AnsverString}"
            };

            QuestionText.text = $"{finalBody}";
        };
    }

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            OnAnsverSelected?.Invoke(AnsverString);
        });
    }
}
