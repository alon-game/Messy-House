using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    [SerializeField] float warningTime = 30f;
    private float totalTime;
    private Color warningColor = Color.red;
    private Color normalColor = Color.white; // timer color text

    private void Start()
    {
        totalTime = remainingTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            UpdateTimerText();
            CheckWarning();
        }
        else
        {
            remainingTime = 0;
            timerText.text = "00:00";
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void CheckWarning()
    {
        if (remainingTime <= warningTime)
        {
            timerText.color = warningColor; // change the color to red
        }
        else if (remainingTime > warningTime)
        {
            timerText.color = normalColor; // change the color to white
        }
    }

    public void AddTime(float timeToAdd)
    {
        remainingTime += timeToAdd;
    }

    public float GetRemainingTime()
    {
        return remainingTime;
    }

    public float GetTotalTime()
    {
        return totalTime;
    }
}
