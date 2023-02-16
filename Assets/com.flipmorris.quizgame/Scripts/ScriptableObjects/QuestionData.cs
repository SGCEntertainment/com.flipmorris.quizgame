using UnityEngine;

[CreateAssetMenu()]
public class QuestionData : ScriptableObject
{
    public string quizName;

    [Space(10)]
    public string subject;
    public string chapter;

    [Space(10)]
    public float totalTimeCount;

    [Space(10), TextArea]
    public string instructions;

    [Space(10)]
    public Question[] questions;
}
