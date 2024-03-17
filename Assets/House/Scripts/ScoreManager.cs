/*using System.Collections;
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
*/

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI pointsText; // Points Text Field
    [SerializeField] TextMeshProUGUI finalScoreText; // Final score Text Field
    [SerializeField] int maxScore;
    [SerializeField] GameObject panel;
    [SerializeField] GameObject[] stars; // Array of star objects representing different levels of performance
    [SerializeField] GameObject[] starsText; // Array of Text objects representing different levels of performance
    private int starsToShow;
    private float scorePercentage;
    private static int score = 0; // Score field
    private Timer timer;
    private PauseMenu pauseMenu;
    private AudioManager audioManager;


    void Start()
    {
        pauseMenu = GetComponent<PauseMenu>();
        pauseMenu.Resume(); // resume the game 
        panel.SetActive(false);
        ResetScore(); // reset the score
        timer = GetComponent<Timer>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }

    private void Update()
    {
        pointsText.text = score.ToString() + " Points"; // update UI text score
        // Check if the player reached the maxScore
        if (score == maxScore || timer.GetRemainingTime() == 0)
        {
            starsToShow = CalculateStarsToShow();
            DisplayStars(starsToShow);
            OpenPanel(); // Open the panel
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            pauseMenu.Pause(); // stop the game
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
        pointsText.text = score.ToString() + " Points";
    }

    void OpenPanel()
    {
        panel.SetActive(true); // Open the panel
    }

    int CalculateStarsToShow()
    {
        // Determine the number of stars to show based on the player's performance
        int starsToShow = 0;
        // Calculate score percentage
        scorePercentage = CalcScorePercentage(score, maxScore);

        if (score == maxScore)
        {
            starsToShow = 3;
            return starsToShow;
            
        }
        //float remainingTimePercentage = Mathf.Clamp01(timer.GetRemainingTime() / timer.GetTotalTime());

        // Check remaining time and score to determine stars
        if (scorePercentage >= 50f)
        {
            starsToShow = 2;
        }
        else if (scorePercentage >= 1f)
        {
            starsToShow = 1;
        }
        else 
        {
            starsToShow = 0;
        }

        return starsToShow;
    }

    public float CalcScorePercentage(int score, int maxScore)
    {
        // Calculation of the percentage of the score from the maximum score
        return (float)score / maxScore * 100;
    }

        void DisplayStars(int starsToShow)
    {
        // Activate the stars based on starsToShow
        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].SetActive(false);
            starsText[i].SetActive(false);
        }
        stars[starsToShow].SetActive(true);
        starsText[starsToShow].SetActive(true);
        int intFinalScore = (int)scorePercentage;
        finalScoreText.text = "Score: " + intFinalScore.ToString();
    }
}
