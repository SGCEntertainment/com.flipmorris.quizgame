using UnityEngine.UI;
using UnityEngine;
using System;

public class ResultModule : MonoBehaviour
{
    private float targetProgress;

    [SerializeField] Image circleProgressAmount;
    [SerializeField] Text progressText;

    [Space(10)]
    [SerializeField] Text correctText;
    [SerializeField] Text wrongText;

    [Space(10)]
    [SerializeField] Text totalTimeText;
    [SerializeField] Text avgTimeText;

    [Space(10)]
    [SerializeField] Text detailsText;

    public void Init(ResultPayload resultPayload)
    {
        targetProgress = (float)resultPayload.correctCount / resultPayload.totalCount;
        
        progressText.text = $"{resultPayload.correctCount}/{resultPayload.totalCount}\nyour score";

        correctText.text = $"{resultPayload.correctCount}";
        wrongText.text = $"{resultPayload.wrongCount}";

        float min = Mathf.RoundToInt(resultPayload.totalTime / 60);
        float sec = Mathf.RoundToInt(resultPayload.totalTime % 60);
        totalTimeText.text = string.Format("{0:00}, {1:00}", min, sec);

        float avgMin = Mathf.RoundToInt(resultPayload.totalTime / resultPayload.totalCount / 60);
        float avgSec = Mathf.RoundToInt(resultPayload.totalTime / resultPayload.totalCount % 60);
        avgTimeText.text = string.Format("{0:00}, {1:00}", avgMin, avgSec);

        float progressPercent = resultPayload.correctCount * 100.0f / resultPayload.totalCount;
        Color color = progressPercent > 60.0f ? Color.green : Color.red;
        string resultString = progressPercent > 60 ? "passed" : "failed";

        detailsText.text = $"Congratulations! \r\nYou have {resultString} this test with {progressPercent}%.";
    }

    private void Update()
    {
        circleProgressAmount.fillAmount = Mathf.MoveTowards(circleProgressAmount.fillAmount, targetProgress, 0.5f * Time.deltaTime);
    }
}
