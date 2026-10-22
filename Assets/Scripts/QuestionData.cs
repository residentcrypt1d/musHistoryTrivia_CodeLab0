using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "QuestionData", menuName = "Scriptable Objects/QuestionData")]
public class QuestionData : ScriptableObject
{
    public string question;
    public string category;
    [Tooltip("The correct answer should always go first, they're randomized later")]
    public string[] answers;
}

// this script is where all the question info goes!