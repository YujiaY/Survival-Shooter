/*
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;


    Animator anim;


    void Awake()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("GameOver");
        }
    }
}
*/

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;       // Reference to the player's health.
    public float restartDelay = 3000f;         // Time to wait before restarting the level


    Animator anim;                          // Reference to the animator component.
    float restartTimer;                     // Timer to count up to restarting the level


    void Awake()
    {
        // Set up the reference.
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        //Scene currentScene = SceneManager.GetActiveScene();
        // get the current scene name 
        string sceneName = SceneManager.GetActiveScene().name;

        // If the player has run out of health...
        if (playerHealth.currentHealth <= 0)
        {
            // ... tell the animator the game is over.
            anim.SetTrigger("GameOver");

            // .. increment a timer to count up to restarting.
            restartTimer += Time.deltaTime;

            // .. if it reaches the restart delay...
            if (restartTimer >= restartDelay)
            {

                // .. then reload the currently loaded level.
                //Application.LoadLevel(Application.loadedLevel);
                if (Input.GetKeyDown(KeyCode.R))
                {
                    // Application.LoadLevel(Application.loadedLevel);

                    // get the current scene name 
                   // string sceneName = SceneManager.GetActiveScene().name;

                    // load the same scene
                    SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
                }
            }
        }
    }
}