using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;

public class AnswerButton : MonoBehaviour
{
    private bool isCorrect;
    [SerializeField] private TextMeshProUGUI answerText;
    [SerializeField] private QuestionSetup questionSetup; // ask a new question after the first question
    
    public GameManager scoring; // reference to other script


    //private int score = 0;
    // public TMP_Text scoreText;

    public void SetAnswerText(string newText)
    {
        answerText.text = newText;
    }

    public void SetIsCorrect(bool newBool)
    {
        isCorrect = newBool;
    }

    public void OnClick()
    {
        if (isCorrect)
        {
            scoring.Scoring();
            // sfxCorrect.Play();
            //scoreText.text = "Grade: " + score;
        }
        else
        {
            Debug.Log("incorrect!!! smh...");
        }

        if (questionSetup.questions.Count > 0) // Get the next question if there are more in the list
        {
            questionSetup.Start(); // Generate a new question
        }
        else scoring.CalculateScore();
    }
}
