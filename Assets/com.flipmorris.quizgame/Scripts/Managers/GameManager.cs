using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get => FindObjectOfType<GameManager>(); }

    public (string quizName, string subjectChapter, int questionCount) Data
    {
        get => (QuestionData.quizName, $"{QuestionData.subject}/{QuestionData.chapter}", QuestionData.questions.Length);
    }

    public float QuestTime
    {
        get => QuestionData.totalTimeCount * 60.0f;
    }

    [SerializeField] GameObject menu;
    [SerializeField] GameObject game;
    [SerializeField] ResultModule result;

    [Space(10)]
    [SerializeField] Text quizName;
    [SerializeField] Text subjectText;
    [SerializeField] Text chapterText;

    [Space(10)]
    [SerializeField] Text totalQuestionsText;
    [SerializeField] Text totalTimeText;
    [SerializeField] Text duplicateTimerText;

    [Space(10)]
    [SerializeField] Text instructionsText;

    [Space(10)]
    [SerializeField] QuestionData QuestionData;

    private void Start() => Init();

    private void Init()
    {
        quizName.text = QuestionData.quizName;
        subjectText.text = QuestionData.subject;
        chapterText.text = QuestionData.chapter;

        totalQuestionsText.text = $"Total Questions: <b>{QuestionData.questions.Length}</b>";
        totalTimeText.text = $"Total Time: <b>{QuestionData.totalTimeCount} min</b>";

        duplicateTimerText.text = $"{QuestionData.totalTimeCount}:00";
        instructionsText.text = QuestionData.instructions;

        game.SetActive(false);
        result.gameObject.SetActive(false);
        menu.SetActive(true);
    }

    public Question GetQuestion(int id)
    {
        return QuestionData.questions[id];
    }

    public void ExitGame() => Application.Quit();

    public void StartGame()
    {
        result.gameObject.SetActive(false);
        menu.SetActive(false);

        game.SetActive(true);
    }

    public void OpenMenu()
    {
        game.SetActive(false);
        menu.SetActive(true);
    }

    public void ShowResult(ResultPayload resultPayload)
    {
        game.SetActive(false);

        result.Init(resultPayload);
        result.gameObject.SetActive(true);
    }
}
