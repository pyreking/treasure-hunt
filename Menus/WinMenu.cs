using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class WinMenu : MonoBehaviour
{
    public Text winMessage;
    public static bool isActive;

    public AudioMixerSnapshot idleSnapshot;
    public GameObject winMenuUi = null;
    public GameObject uiOverlay = null;
    public Timer timer = null;

    public void Update()
    {
        if (isActive)
        {
            Activate();
        }
    }

    public void Activate()
    {
        Time.timeScale = 0;
        Destroy(GameObject.Find("Player"));
        string finalTime = timer.getFinalTime();
        winMessage.text = string.Format($"YOU FINISHED IN {finalTime}. CAN YOU DO BETTER?");

        winMenuUi.SetActive(true);
        uiOverlay.SetActive(false);
        Time.timeScale = 0f;
        AudioListener.pause = true;
    }

    public void Disable()
    {
        winMenuUi.SetActive(false);
        uiOverlay.SetActive(true);
        Time.timeScale = 1f;
        AudioListener.pause = false;
        ItemManager.Reset();
    }

    public void RestartGame()
    {
        ItemManager.Reset();
        isActive = false;
        ThirdPersonCharacter.insideHurtPlane = false;
        ThirdPersonCharacter.onPlatform = false;
        idleSnapshot.TransitionTo(0.5f);
        SceneManager.LoadScene("IslandScene");
        Disable();
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