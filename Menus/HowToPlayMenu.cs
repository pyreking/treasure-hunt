using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlayMenu : MonoBehaviour
{

    public GameObject pauseMenuUI = null;
    public GameObject howToPlayMenuUI = null;
    public static bool isActive = false;

    public void Update()
    {
        if (isActive)
        {
            Activate();
        }
    }

    public void Activate()
    {
        pauseMenuUI.SetActive(false);
        howToPlayMenuUI.SetActive(true);
        isActive = true;
    }

    public void Disable()
    {
        howToPlayMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        isActive = false;
    }
}