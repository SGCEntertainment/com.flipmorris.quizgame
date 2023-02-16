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

    [Space(10)]
    [SerializeField] Text questionCountText;
    [SerializeField] Text questionBodyText;

    public static Action<Question> OnQuestionUpdated { get; set; }

    private void OnEnable()
    {
        timeCount = 0;
        questionId = 0;

        totalQuestionCount = GameManager.Instance.Data.questionCount;
        progressAmount.fillAmount = questionId / totalQuestionCount;
    }

    private void Start() => Init();

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

        UpdateQuestion();
    }

    private void UpdateQuestion()
    {
        questionCountText.text = $"Q.{questionId}/{GameManager.Instance.Data.questionCount}";
        questionBodyText.text = GameManager.Instance.CurrentQuestion.question;

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
