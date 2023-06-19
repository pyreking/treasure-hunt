using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Animator titleOverlay = null;
    public Animator authorOverlay = null;

    public Animator startButton;
    public Animator settingsButton;
    public Animator quitButton;
    public Animator dialog;

    public void OpenHowToPlay()
    {
        titleOverlay.SetBool("isHidden", true);
        authorOverlay.SetBool("isHidden", true);
        startButton.SetBool("isHidden", true);
        settingsButton.SetBool("isHidden", true);
        quitButton.SetBool("isHidden", true);
        dialog.SetBool("isHidden", false);
    }

    public void CloseHowToPlay()
    {
        titleOverlay.SetBool("isHidden", false);
        authorOverlay.SetBool("isHidden", false);
        startButton.SetBool("isHidden", false);
        settingsButton.SetBool("isHidden", false);
        quitButton.SetBool("isHidden", false);
        dialog.SetBool("isHidden", true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("IslandScene");
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