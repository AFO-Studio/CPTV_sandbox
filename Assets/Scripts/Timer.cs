using System;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;

    public float timeStart;
    public float time = 10;
    public float timeDefualt = 10;
    public float timeEnd;

    public string count;

    [HideInInspector]
    public bool updateText = true;

    public bool runTimer = true;

    private void Start()
    {
        Time.timeScale = 1;

        timeStart = Time.time;
    }

    private void FixedUpdate()
    {
        if (runTimer == true)
        {
            updateText = !updateText;

            if (updateText)
            {
                if (count == "Down")
                {
                    var step = timeStart + time - Time.time;
                    var seconds = step % 60;

                    timerText.text = string.Format("{0}", Math.Round(seconds, 0));
                }
                if (count == "Up")
                {
                    time = Time.time - timeStart;
                    var seconds = time % 60;

                    timerText.text = string.Format("{0}", Math.Round(seconds, 0));
                }
            }
        }
    }

    public void Reset()
    {
        timeStart = Time.time;
        time = timeDefualt;
        Start();
    }
}