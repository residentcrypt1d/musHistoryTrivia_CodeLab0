using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TMP_Text ScoreText;
    public TMP_Text HighScoreText;
    
    private int score;
    private int highScore;
    
    public GameObject startGameCanvas; // Assign in inspector
    public GameObject endGameCanvas; // Assign in inspector
    public GameObject mainGameCanvas; // see above lmao
    private bool isShowing;
    
    public TMP_Text ResultsText;

    //public AudioSource sfxCorrect; // will i be adding this? who knows...


    void Awake()
    {
        startGameCanvas.SetActive(true); // should make start canvas visible on runtime?????
        endGameCanvas.SetActive(false); // trying to make this not show up
        mainGameCanvas.SetActive(false); // trying to make this not show up
    }

    void Start()
    {
        score = 0;
        highScore = 0;
        //ScoreText.text = "Score:" + score;
    }
    
    void Update() {
        if ((UnityEngine.InputSystem.Keyboard.current.vKey.wasPressedThisFrame))
        {
            startGameCanvas.SetActive(false);
            mainGameCanvas.SetActive(true);
            Debug.Log("pressed V");
            HighScoreText.text = "high score: " + highScore + "/5";
        }
        if ((UnityEngine.InputSystem.Keyboard.current.bKey.wasPressedThisFrame))
        {
            endGameCanvas.SetActive(false);
            mainGameCanvas.SetActive(true);
            Debug.Log("pressed B");
            score = 0;
            
            //HighScoreText.text = "high score: " + (highScore <= 5) + "/5";
        }
    }
    
    public void Scoring() // adds to the score total
    {
        score++;
        Debug.Log("score = " + score);
    }

    public void CalculateScore() // calculates final score (there's definitely a better way to do this)
    {
        if (score == 0)
        {
            //SceneManager.LoadScene("gameOver_00");
            Debug.Log("0/5 score");
            ResultsText.text = "0/5... yikes dude, drop out";
        }
        else if (score == 1)
        {
            mainGameCanvas.SetActive(false);
            endGameCanvas.SetActive(true);
            //SceneManager.LoadScene("gameOver_01");
            Debug.Log("1/5 score");
            ResultsText.text = "1/5, better than nothing!";
        }
        else if (score == 2)
        {
            mainGameCanvas.SetActive(false);
            endGameCanvas.SetActive(true);
            //SceneManager.LoadScene("gameOver_02");
            Debug.Log("2/5 score");
            ResultsText.text = "2/5, that's almost a 50%";
        }
        else if (score == 3)
        {
            mainGameCanvas.SetActive(false);
            endGameCanvas.SetActive(true);
            //SceneManager.LoadScene("gameOver_03");
            Debug.Log("3/5 score");
            ResultsText.text = "3/5, not bad for winging it. did you guess";
        }
        else if (score == 4)
        {
            mainGameCanvas.SetActive(false);
            endGameCanvas.SetActive(true);
            //SceneManager.LoadScene("gameOver_04");
            Debug.Log("4/5 score");
            ResultsText.text = "4/5, yooooooooo";
        }
        else if (score == 5)
        {
             mainGameCanvas.SetActive(false);
             endGameCanvas.SetActive(true);
             //SceneManager.LoadScene("gameOver_05");
             Debug.Log("5/5 score!!!");
             ResultsText.text = "5/5, a perfect score!";
        }
        if (score > highScore) // displays the high score!
        {
            highScore = score;
            HighScoreText.text = "high score: " + highScore + "/5";
        }
    }
}

    
  