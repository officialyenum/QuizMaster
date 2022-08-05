using System.Collections;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class CategoryHandler : MonoBehaviour
{
    DifficultyHandler difficultyHandler;
    Quiz quiz;
    GameManager gameManager;
    public class QuestionModelJsonResponse
    {
        public int response_code { get; set; }
        public List<QuestionModel> results { get; set; }
    }
    public class QuestionModel
    {
        public string category { get; set; }
        public string type { get; set; }
        public string difficulty { get; set; }
        public string question { get; set; }
        public string correct_answer { get; set; }
        public List<string> incorrect_answers { get; set; }
    }
    void Awake()
    {
        difficultyHandler = FindObjectOfType<DifficultyHandler>();
        quiz = FindObjectOfType<Quiz>();
        gameManager = FindObjectOfType<GameManager>();
    }

    public void ShowDifficultCategory()
    {
        difficultyHandler.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ShowSelectQuiz()
    {
        quiz.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    public void SetCategoryName(string name)
    {
        gameManager.categoryName = name;
    }

    public void SetCategory(int num)
    {
        gameManager.category = num;
        StartCoroutine("LoadQuestions");
    }

    public int GetCategory()
    {
        return gameManager.category;
    }

    [System.Obsolete]
    IEnumerator LoadQuestions()
    {
        int amount = 10;
        int category = gameManager.category;
        var difficulty = gameManager.difficulty;
        var type = "multiple";
        Debug.Log($"https://opentdb.com/api.php?amount={amount}&category={category}&difficulty={difficulty}&type={type}");
        string uri = $"https://opentdb.com/api.php?amount={amount}&category={category}&difficulty={difficulty}&type={type}";
        using (UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
            {
                Debug.Log("error " + request.error);
            }
            else
            {
                var text = request.downloadHandler.text;
                QuestionModelJsonResponse questionModelJson = JsonConvert.DeserializeObject<QuestionModelJsonResponse>(text);
                ProcessQuiz(questionModelJson);
                ShowSelectQuiz();
            }
        }
    }

    void ProcessQuiz(QuestionModelJsonResponse json)
    {
        List<Question> questionList = new List<Question>();
        foreach (QuestionModel item in json.results)
        {
            List<string> _answers = new List<string>();
            foreach (string incorrect in item.incorrect_answers)
            {
                _answers.Add(WebUtility.HtmlDecode(incorrect));
            }
            int randomIndex = Random.Range(0, 3);
            _answers.Insert(randomIndex, WebUtility.HtmlDecode(item.correct_answer));
            Question _question = new Question(WebUtility.HtmlDecode(item.question), _answers, randomIndex);
            questionList.Add(_question);
        }

        quiz.SetQuestions(questionList);
    }

}
