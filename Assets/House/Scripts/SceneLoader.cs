using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    private static SceneLoader instance; // static instance of SceneLoader
    private ScoreManager scoreManager;

    void Start()
    {
        scoreManager = GameObject.FindGameObjectWithTag("Points").GetComponent<ScoreManager>(); // get the scoreManager component
    }

    // static function that returns the instance of the class 
    public static SceneLoader Instance
    {
        get
        {
            if (instance == null) 
            {
                GameObject obj = new GameObject("SceneLoader"); // initialize SceneLoader and store it in instance
                instance = obj.AddComponent<SceneLoader>();
            }
            return instance;
        }
    }

    // This function gets the name of the scene we want to load and performs the loading operation
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


    public void LoadNextScene()
    {
        if (SceneManager.GetActiveScene().name == "Tutorial") // if the current scene is tutorial
        {
            if (scoreManager != null && scoreManager.GetScore() == 2) // check If the player arranged 2 objects
            {
                scoreManager.ResetScore(); // reset the score field
                SceneManager.LoadScene("Level 1"); // load the next scene
            }
        }
    }
}

