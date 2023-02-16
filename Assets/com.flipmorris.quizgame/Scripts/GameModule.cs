using UnityEngine.UI;
using UnityEngine;
using System;

public class GameModule : MonoBehaviour
{
    private float timeCount;

    private int questionId;
    private int totalQuestionCount;

    [SerializeField] Text quizNameText;
    [SerializeField] Text subjectAndChapterText;

    [Space(10)]
    [SerializeField] Image progressAmount;
    [SerializeField] Text timerText;

    public static Action<Question> OnQuestionUpdated { get; set; }

    private void OnEnable() => Init();

    private void Awake()
    {
        AnsverBtn.OnAnsverSelected += (id) =>
        {
            Debug.Log(id);
        };
    }

    public void Init()
    {
        quizNameText.text = GameManager.Instance.Data.quizName;
        subjectAndChapterText.text = GameManager.Instance.Data.subjectChapter;

        timeCount = 0;
        questionId = 0;

        totalQuestionCount = GameManager.Instance.Data.questionCount;
        progressAmount.fillAmount = questionId / totalQuestionCount;

        OnQuestionUpdated?.Invoke(GameManager.Instance.CurrentQuestion);
    }

    private void Update()
    {
        timeCount += Time.deltaTime;

        float min = Mathf.RoundToInt(timeCount / 60);
        float sec = Mathf.RoundToInt(timeCount % 60);

        timerText.text = string.Format("{0:00}:{1:00}", min, sec);
    }
}
