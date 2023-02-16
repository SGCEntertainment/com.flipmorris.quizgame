using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get => FindObjectOfType<GameManager>(); }

    public (string quizName, string subjectChapter, int questionCount) Data
    {
        get => (QuestionData.quizName, $"({QuestionData.subject}/{QuestionData.chapter})", QuestionData.questions.Length);
    }

    public Question CurrentQuestion
    {
        get => QuestionData.questions[questionId];
    }

    private int questionId;

    [SerializeField] GameObject menu;
    [SerializeField] GameObject game;
    [SerializeField] GameObject result;

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
        result.SetActive(false);
        menu.SetActive(true);
    }

    public void ExitGame() => Application.Quit();

    public void StartGame()
    {
        questionId = 0;

        result.SetActive(false);
        menu.SetActive(false);

        game.SetActive(true);
    }

    public void OpenMenu()
    {
        game.SetActive(false);
        menu.SetActive(true);
    }
}
