using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TMP_Text ScoreText;
    public TMP_Text HighScoreText;
    
    private int score;
    private int highScore;
    
    public GameObject startCanvas; // Assign in inspector
    public GameObject endCanvas; // Assign in inspector
    private bool isShowing;
    
    public TMP_Text ResultsText;

    //public AudioSource sfxCorrect; // will i be adding this? who knows...
   

    void Start()
    {
        score = 0;
        highScore = 0;
        //ScoreText.text = "Score:" + score;

        startCanvas.SetActive(true);
        endCanvas.SetActive(false);
    }
    


    void Update() {
        if ((UnityEngine.InputSystem.Keyboard.current.bKey.wasPressedThisFrame))
        {
            isShowing = !isShowing; 
            startCanvas.SetActive(isShowing);
            Debug.Log("pressed B");
        }
    }
    
    
    
    public void Scoring()
    {
        score++;
        Debug.Log("score = " + score);
    }

    public void CalculateScore()
    {
        if (score == 0)
        {
            //SceneManager.LoadScene("gameOver_00");
            Debug.Log("0/5 score");
        }
        else if (score == 1)
        {
            //SceneManager.LoadScene("gameOver_01");
            Debug.Log("1/5 score");
        }
        else if (score == 2)
        {
            //SceneManager.LoadScene("gameOver_02");
            Debug.Log("2/5 score");
        }
        else if (score == 3)
        {
            //SceneManager.LoadScene("gameOver_03");
            Debug.Log("3/5 score");
        }
        else if (score == 4)
        {
            //SceneManager.LoadScene("gameOver_04");
            Debug.Log("4/5 score");
        }
        else if (score == 5)
        {
             //SceneManager.LoadScene("gameOver_05");
            Debug.Log("5/5 score!!!");
        }
        if (score > highScore)
        {
            highScore = score;
            HighScoreText.text = "high score: " + highScore + "/5";
        }
    }

    // void EndGame()
    //{
    //gameScreen.SetActive(false);
    // SceneManager.LoadScene("Scenes/endGame");

/*        void UpdateScore(int scoreToAdd)
        {
            sfxCorrect.Play();
            score += scoreToAdd;
            ScoreText.text = "Grade: " + score;
            if (score == 6)
            {
                EndGame();
            }
        }
    }*/
}

    
  