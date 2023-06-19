using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverMenuUI = null;
    public static bool gameOver = false;

    void Update()
    {
        if (gameOver)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        gameOverMenuUI.SetActive(true);
        gameOver = true;
        Time.timeScale = 0f;
        AudioListener.pause = true;
    }

    public void RestartGame()
    {
        ItemManager.Reset();
        gameOver = false;
        ThirdPersonCharacter.insideHurtPlane = false;
        ThirdPersonCharacter.onPlatform = false;
        SceneManager.LoadScene("IslandScene");
        Resume();
    }

    public void QuitGame()
    {
     #if UNITY_EDITOR
         UnityEditor.EditorApplication.isPlaying = false;
     #else
         Application.Quit();
     #endif
    }

    void Resume()
    {
        gameOverMenuUI.SetActive(false);
        gameOver = false;
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }
}