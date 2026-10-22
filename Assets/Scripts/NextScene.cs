using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public void TriviaTime()
    {
        SceneManager.LoadScene("triviaGame");
        Debug.Log("clicked button");
    }
}