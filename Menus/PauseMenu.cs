using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    public AudioMixerSnapshot idleSnapshot;
    public GameObject pauseMenuUI = null;
    public GameObject uiOverlay = null;
    public static bool isPaused;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !GameOverMenu.gameOver)
        {
            if (isPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        uiOverlay.SetActive(false);
        pauseMenuUI.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
        AudioListener.pause = true;
    }

    void Resume()
    {
        uiOverlay.SetActive(true);
        pauseMenuUI.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }

    public void RestartGame()
    {
        ItemManager.Reset();
        ThirdPersonCharacter.insideHurtPlane = false;
        ThirdPersonCharacter.onPlatform = false;
        idleSnapshot.TransitionTo(0.5f);
        SceneManager.LoadScene("IslandScene");
        Resume();
    }

    public void ResumeGame()
    {
        Resume();
    }

    public void ShowHowToPlay()
    {
        HowToPlayMenu.isActive = true;
    }

    public void QuitGame()
    {
     #if UNITY_EDITOR
         UnityEditor.EditorApplication.isPlaying = false;
     #else
         Application.Quit();
     #endif
    }
}
