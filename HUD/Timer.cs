using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    //Maximum time to complete level (in seconds)
    public float MaxTime = 60f;
    public Text timer;
    //Countdown
    [SerializeField]
    private float CountDown = 0;
    // Use this for initialization
    void Start()
    {
        CountDown = MaxTime;
    }
    // Update is called once per frame
    void Update()
    {
        //Reduce time
        if (CountDown > 0)
        {
            int minutes = Mathf.FloorToInt(CountDown / 60F);
            int seconds = Mathf.FloorToInt(CountDown - minutes * 60);
            timer.text = string.Format("{0:0}:{1:00}", minutes, seconds);
            CountDown -= Time.deltaTime;
        }

        if (CountDown <= 0)
        {
            Destroy(GameObject.Find("Player"));
            GameOverMenu.gameOver = true;
            CountDown = MaxTime;
        }
    }

    public string getFinalTime()
    {
        int minutes = Mathf.FloorToInt((MaxTime - CountDown) / 60F);
        int seconds = Mathf.FloorToInt((MaxTime - CountDown) - minutes * 60);
        string finalTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        return finalTime;
    }
}