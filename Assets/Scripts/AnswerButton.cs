using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class AnswerButton : MonoBehaviour
{
    private bool isCorrect;
    [SerializeField] private TextMeshProUGUI answerText;
    [SerializeField] private QuestionSetup questionSetup; // ask a new question after the first question

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
            Debug.Log("correct!");
        }
        else
        {
            Debug.Log("incorrect!!! smh...");
        }
        
        if (questionSetup.questions.Count > 0) // Get the next question if there are more in the list
        {
            questionSetup.Start();  // Generate a new question
        }
    }
}
