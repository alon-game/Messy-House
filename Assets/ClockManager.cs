using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockManager : MonoBehaviour
    {
    public GameObject clockObject; // Clock object to be shown
    public float timeToShowClock = 30f; // Time to show the clock

    private Timer timer; // Reference to the Timer component
    private bool clockShown = false; // Flag to indicate if the clock has been shown

    void Start()
    {
        clockObject.SetActive(false);
        timer = GetComponent<Timer>(); // Get the Timer component from the game object
    }

    void Update()
    {
        // Check if the timer has reached the specified time to show the clock and the clock has not been shown yet
        if (!clockShown && timer.GetRemainingTime() <= timeToShowClock)
        {
            ShowClock(); // Show the clock
        }
    }

    void ShowClock()
    {
        if (clockObject != null)
        {
            clockObject.SetActive(true); // Activate the clock object
            clockShown = true; // Mark the clock as shown
        }
    }
}
