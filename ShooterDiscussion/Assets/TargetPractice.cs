using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TargetPractice : MonoBehaviour
{
    public TMP_Text stopwatchText;
    
    struct TimeData
    {
        public int seconds;
        public float miliseconds;
    }

    TimeData time;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StopwatchTextUpdate();
    }

    void StopwatchTextUpdate()
    {
        time.miliseconds += Time.deltaTime;
        if (time.miliseconds > 1f)
        {
            time.seconds++;
            time.miliseconds = 0;
        }
        stopwatchText.text = FormatTime(time.seconds, time.miliseconds);
    }

    string FormatTime(int seconds, float miliseconds)
    {

        return seconds + ":" + (int)(miliseconds * 100f);
    }
}
