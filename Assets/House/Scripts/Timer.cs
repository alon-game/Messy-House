using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    [SerializeField] float warningTime = 30f;
    private Color warningColor = Color.red;

    private bool isWarningDisplayed = false;

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
        if (remainingTime <= warningTime && !isWarningDisplayed)
        {
            timerText.color = warningColor;
            isWarningDisplayed = true;
        }
    }

    public void AddTime(float timeToAdd)
    {
        remainingTime += timeToAdd;
    }
}
