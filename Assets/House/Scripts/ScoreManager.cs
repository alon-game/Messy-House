using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] Text scoreText; // Score Text Field
    [SerializeField] int maxScore;
    [SerializeField] GameObject panel;
    private static int score = 0; // Score field

    void Start()
    {
        panel.SetActive(false); 
        ResetScore();
    }

    private void Update()
    {
        scoreText.text = score.ToString() + " Points"; // update UI text score
        // Check if the player reached the maxScore
        if (score == maxScore)
        {
            OpenPanel(); // Open the panel
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
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
    void OpenPanel()
    {
        panel.SetActive(true); // Open the panel
    }
}
