using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timer;
    public float timerFix = 10;
    private bool timerCountdown;

    // Start is called before the first frame update
    void Start()
    {
        timerCountdown = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerCountdown)
        {
            timerFix -= Time.deltaTime;
            TimerGerak();
        }
        else
        {
            timerFix = 0;
            timerCountdown = false;
        }
        
    }

    void TimerGerak()
    {
        float minutes = Mathf.FloorToInt(timerFix / 60);
        float seconds = Mathf.FloorToInt(timerFix % 60);
        timer.text = string.Format("{0:00} : {1:00}", minutes, seconds);   
    }
}
