using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTime : MonoBehaviour
{
    [SerializeField] GameObject feedbackMessageUI; // Feedback message when the player gets extra time
    private Timer timer;
    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        timer = GameObject.FindGameObjectWithTag("Level Manager").GetComponent<Timer>();
        //timer = FindObjectOfType<Timer>();
        feedbackMessageUI.SetActive(false); // disable feedback message
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timer.AddTime(30f);
            gameObject.SetActive(false);
            feedbackMessageUI.SetActive(true); // Enable the feedback message for the player
            audioManager.PlaySFX(audioManager.extraTime);
            Invoke("SetInactiveUI", 2f); // Disable the feedback message afer 2 seconds
        }
    }

    // Disable the feedback message
    private void SetInactiveUI()
    {
        feedbackMessageUI.SetActive(false);
    }
}
