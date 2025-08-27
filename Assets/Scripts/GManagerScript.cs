using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class GManagerScript : MonoBehaviour

{

    [System.Serializable] //to add the questions from inspector.
    public class QA
    {
        public string question;
        public string correctAnswer;              //the structure for the questions
        public string wrongAnswer;
    }

    [SerializeField] QA[] questionList;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;

    public GameObject ballPrefab;
    public Transform ballSpawnPoint;

    private GameObject currentBall;
    public TextMeshProUGUI questionText;
    public TextMeshPro leftAnswerText;
    public TextMeshPro rightAnswerText;


    public TextMeshProUGUI scoreText;

    [SerializeField]  Image heart1, heart2, heart3;

    public GameObject leftGoal;
    public GameObject rightGoal;

    private int score = 0;
    private int lives = 3;
    private int currentQuestion = 0;
    private bool correctOnRight;
    public AudioScript audioManager;


    void Start()
    {
        winPanel.SetActive(false);
        losePanel.SetActive(false);

        ShowQuestion();
        scoreText.text = "Score: 0";

    }

    void ShowQuestion()
    {
        // to restart teh question if we reach the end of the array list of questions.
        if (currentQuestion >= questionList.Length)
        {
            currentQuestion = 0;
        }




        questionText.text = questionList[currentQuestion].question;


        correctOnRight = Random.value > 0.5f;

        if (correctOnRight)
        {
            rightAnswerText.text = questionList[currentQuestion].correctAnswer;
            leftAnswerText.text = questionList[currentQuestion].wrongAnswer;             // here to randomize the answes side.
        }
        else
        {
            leftAnswerText.text = questionList[currentQuestion].correctAnswer;
            rightAnswerText.text = questionList[currentQuestion].wrongAnswer;
        }
    }





    public void HandleGoalHit(bool? isRight)//this is right for to determine the side og hit ball(true for right goal)(false for left), also to receve null I use?.
    {
        if (isRight == null)
        {
            audioManager.PlayBuzzer();
            lives--;

            if (lives == 2) heart3.enabled = false;
            if (lives == 1) heart2.enabled = false;//   here the miss zones handle as a wrong answers.

            if (lives <= 0)
            {
                heart1.enabled = false;
               
            
                Invoke("ShowLoseScreen", 1f);
                audioManager.PlayLoseSound();
                return;
            }

           
            return;
        }
        //correct  OnRight to handle if it is corect on right, if doesn't it is wrong
        bool isCorrect = (isRight == true && correctOnRight) || (isRight == false && !correctOnRight);

        if (isCorrect)
        {
            audioManager.PlayGoal();
            score++;
            scoreText.text = "Score: " + score;


        }
        else
        {
            audioManager.PlayBuzzer();
            lives--;
            if (lives == 2) heart3.enabled = false;
            if (lives == 1) heart2.enabled = false;
            if (lives == 0)
            {
                heart1.enabled = false;
                Debug.Log("YOU LOSE!");
               
                Invoke("ShowLoseScreen", 1f);
                audioManager.PlayLoseSound();
                return;
            }
        }

        currentQuestion++;
        if (currentQuestion >= questionList.Length && lives > 0)
        {
            Debug.Log("YOU WIN!");
            

            Invoke("ShowWinScreen", 1f);
            audioManager.PlayWinSound();

            return;
        }
        Invoke("ShowQuestion", 1.6f); 
    }
    

    void ShowWinScreen()
    {
        audioManager.StopCrowd();
        winPanel.SetActive(true);
    }

    void ShowLoseScreen()
    {
        audioManager.StopCrowd();
        losePanel.SetActive(true);
    }

    public void RestartGame()
    {
        Debug.Log("Restart button clicked!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMainMenu()
    {
        Debug.Log("Main Menu button clicked!");
        SceneManager.LoadScene("MainMenu");
    }

    public void GoToLevel2()
    {
        Debug.Log("Go To Level 2 button clicked!");
        SceneManager.LoadScene("level2"); 
    }

}

