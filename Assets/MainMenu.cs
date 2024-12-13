using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Get the next scene index
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        // Check if the next scene index is valid
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            // Load the next scene
            Debug.Log("Loading scene: " + nextSceneIndex);
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogError("Next scene index is out of range!");
        }
    }

    public void QuitGame()
    {
        // Log quitting the game
        Debug.Log("Quitting game...");

        // Quit the game
        Application.Quit();
    }

    void ShowDifficultyPanel(GameObject gameObject)
    {
        gameObject.SetActive(true); // Show the difficulty panel
    }
}
