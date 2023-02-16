using UnityEngine.UI;
using UnityEngine;
using System;

public class GameModule : MonoBehaviour
{
    private float timeCount;

    private int questionId;
    private int totalQuestionCount;
    
    private Question Current { get; set; }

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
            questionId++;
            if(questionId >= totalQuestionCount)
            {
                GameManager.Instance.ShowResult();
                return;
            }

            SetQuestion();
        };
    }

    public void Init()
    {
        Current = GameManager.Instance.GetQuestion(questionId);

        quizNameText.text = GameManager.Instance.Data.quizName;
        subjectAndChapterText.text = GameManager.Instance.Data.subjectChapter;

        SetQuestion();
    }

    private void SetQuestion()
    {
        Current = GameManager.Instance.GetQuestion(questionId);

        questionCountText.text = $"Q.{questionId + 1}/{GameManager.Instance.Data.questionCount}";
        questionBodyText.text = Current.question;

        OnQuestionUpdated?.Invoke(Current);

        AnsverBtn[] ansverBtns = FindObjectsOfType<AnsverBtn>();
        foreach(AnsverBtn ab in ansverBtns)
        {
            ab.gameObject.SetActive(false);
        }

        foreach (AnsverBtn ab in ansverBtns)
        {
            ab.gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        timeCount += Time.deltaTime;

        float min = Mathf.RoundToInt(timeCount / 60);
        float sec = Mathf.RoundToInt(timeCount % 60);

        timerText.text = string.Format("{0:00}:{1:00}", min, sec);
    }
}
