using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public static int previousLevelIndex = -1;

    public void GoToLevel(int levelIndex)
    {
        previousLevelIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(levelIndex);
    }
    
    public void ReturnToPreviousLevel()
    {
        if (previousLevelIndex >= 0)
        {
            SceneManager.LoadSceneAsync(previousLevelIndex);
        }
        else
        {
            Debug.LogWarning("No previous level stored.");
        }
    }
}
