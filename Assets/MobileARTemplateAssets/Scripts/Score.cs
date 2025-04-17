using UnityEngine;
using TMPro;

public class GameScore : MonoBehaviour {

    public TextMeshProUGUI text;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    public int score = 0;

    public void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase ==
            TouchPhase.Began)
            
        {
            RemoveHeart();
            SetScore();
        }
    }

    //take the score from RaiseScore() and set it as a String value.  Then use that string to replace the current score on the text feild inside a canvas
    void SetScore()
    {
        score += 1;
        string scoreText = "Score : " + score.ToString();
        // Debug successfully updates the score on the Console.
        Debug.Log(scoreText);
        //NullReferenceException: Object reference not set to an instance of an object Solution
        text.text = scoreText;
    }

    void RemoveHeart()
    {
        // Animate the heart to be removed
        if (heart1.activeSelf)
        {
            heart1.SetActive(false);
        }
        else if (heart2.activeSelf)
        {
            heart2.SetActive(false);
        }
        else if (heart3.activeSelf)
        {
            heart3.SetActive(false);
        }
        else
        {
            Debug.Log("No hearts left to remove.");
        }
    }
}