using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] Text scoreText; // Score Text Field 
    private static int score = 0; // Score field

    private void Update()
    {
        scoreText.text = score.ToString() + " Points"; // update UI text score
    }
    public int GetScore() // return the score value
    {
        return score;
    }

    public void ResetScore() // reset the score to 0 for the next Scene
    {
        score = 0;
    }

    public void AddPoint() // Add 1 point for each object returned to the location 
    {
        score += 1;
        Debug.Log("Score: " + score);
        scoreText.text = score.ToString() + " Points";
    }
}
