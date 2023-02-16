using UnityEngine.UI;
using UnityEngine;

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

    private void OnEnable() => Init();

    public void Init()
    {
        quizNameText.text = GameManager.Instance.data.quizName;
        subjectAndChapterText.text = GameManager.Instance.data.subjectChapter;

        timeCount = 0;
        questionId = 0;

        totalQuestionCount = GameManager.Instance.data.questionCount;
        progressAmount.fillAmount = questionId / totalQuestionCount;
    }

    private void Update()
    {
        timeCount += Time.deltaTime;

        float min = Mathf.RoundToInt(timeCount / 60);
        float sec = Mathf.RoundToInt(timeCount % 60);

        timerText.text = string.Format("{0:00}:{1:00}", min, sec);
    }
}
