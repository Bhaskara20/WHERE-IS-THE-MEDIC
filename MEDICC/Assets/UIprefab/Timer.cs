using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timer;
    public float timerFix = 10;
    private bool timerCountdown;

    public GameObject finish;
    public GameObject failed;
    public bool isFinished;

    public GameObject patientCounter;

    public float goal;

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

        //win lose condition
        if (timerFix <= 0f)
        {
            timerFix = 0;
            
            //win
            if (patientCounter.GetComponent<counter>().nums == goal)
            {
                finish.SetActive(true);
                PauseGame();
            }else if (patientCounter.GetComponent<counter>().nums <= goal)
            {
                //Debug.Log("KALAH");
                failed.SetActive(true);
                PauseGame();
            }

            
        }
        


    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }

    void TimerGerak()
    {
        float minutes = Mathf.FloorToInt(timerFix / 60);
        float seconds = Mathf.FloorToInt(timerFix % 60);
        timer.text = string.Format("{0:00} : {1:00}", minutes, seconds);   
    }
}
