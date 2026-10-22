using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class QuestionSetup : MonoBehaviour
{
   [SerializeField] public List<QuestionData> questions; // calling other script
   public QuestionData currentQuestion; // going to make it so we don't repeat questions within a session
   [SerializeField] private TextMeshProUGUI questionText; // connect to text
   [SerializeField] private TextMeshProUGUI categoryText; // connect to text
   [SerializeField] private AnswerButton[] answerButtons;

   [SerializeField] private int correctAnswerChoice; // keeping track of which answer is correct

   private void Awake()
   {
      GetQuestionAssets(); // pulling our question assets when scene loads.
   }

   public void Start()
   {
      SelectNewQuestion(); // select a new question! randomly!
      SetQuestionValues(); // set all text & values on screen.
      SetAnswerValues(); // set the answer values rahhhh
   }

   private void GetQuestionAssets() // get all of our questions from the resources folder
   {
      questions = new List<QuestionData>(Resources.LoadAll<QuestionData>("Questions"));
   }

   private void SelectNewQuestion()
   {
      int randomQuestionIndex = Random.Range(0, questions.Count); // random question from our pool. count bc its a list. array would be length
      currentQuestion = questions[randomQuestionIndex]; // set question to random index
      questions.RemoveAt(randomQuestionIndex); // remove from index so it cannot be repeated in the same session
   }

   private void SetQuestionValues()
   {
      questionText.text = currentQuestion.question; // display Q text
      categoryText.text = currentQuestion.category; // display C text
   }

   private void SetAnswerValues()
    {
        // Randomize the answer button order
        List<string> answers = RandomizeAnswers(new List<string>(currentQuestion.answers));

        // Set up the answer buttons
        for (int i = 0; i < answerButtons.Length; i++)
        {
            // Create a temporary boolean to pass to the buttons
            bool isCorrect = false;

            // If it is the correct answer, set the bool to true
            if(i == correctAnswerChoice)
            {
                isCorrect = true;
            }

            answerButtons[i].SetIsCorrect(isCorrect);
            answerButtons[i].SetAnswerText(answers[i]);
        }
    }

   private List<string> RandomizeAnswers(List<string> originalList)
   {
      bool correctAnswerChosen = false;
      List<string> newList = new List<string>();
      for (int i = 0; i < answerButtons.Length; i++)
      {
         int random = Random.Range(0, originalList.Count); // get a random number of the remaining choices
         if (random == 0 && !correctAnswerChosen) // if the random number is 0, this is the correct answer
         {
            correctAnswerChoice = i;
            correctAnswerChosen = true;
         }

         newList.Add(originalList[random]); // add to new list
         originalList.RemoveAt(random); // remove from og list bc it's been used
      }

      return newList;
   }
}
