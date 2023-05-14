using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timer;
    public int seconds;
    public Text TimerText;

    void Start()
    {
        timer = 0.0f;
        TimerText.text = timer.ToString();
    }

    void Update()
    {
        timer += Time.deltaTime;
        seconds = (int)(timer % 60);
        TimerText.text = seconds.ToString();
    }

}
