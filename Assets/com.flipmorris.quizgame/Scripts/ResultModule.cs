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

    private void OnEnable()
    {
        targetProgress = 0;
    }

    public void Init(ResultPayload resultPayload)
    {
        targetProgress = (float)resultPayload.correctCount / resultPayload.totalCount;
        progressText.text = $"{resultPayload.correctCount}/{resultPayload.totalCount}";

        correctText.text = $"{resultPayload.correctCount}";
        wrongText.text = $"{resultPayload.wrongCount}";

        float min = Mathf.RoundToInt(resultPayload.totalTime / 60);
        float sec = Mathf.RoundToInt(resultPayload.totalTime % 60);
        totalTimeText.text = string.Format("{0:00}, {1:00}", min, sec);

        float avgMin = Mathf.RoundToInt(resultPayload.totalTime / resultPayload.totalCount / 60);
        float avgSec = Mathf.RoundToInt(resultPayload.totalTime / resultPayload.totalCount % 60);
        avgTimeText.text = string.Format("{0:00}, {1:00}", avgMin, avgSec);
    }

    private void Update()
    {
        circleProgressAmount.fillAmount = Mathf.MoveTowards(circleProgressAmount.fillAmount, targetProgress, 0.5f * Time.deltaTime);
    }
}
