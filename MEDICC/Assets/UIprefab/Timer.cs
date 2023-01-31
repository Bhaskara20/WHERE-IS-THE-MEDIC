using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timer;
    public TextMeshProUGUI goalText;

    public float timerFix = 10;
    private bool timerCountdown;

    public GameObject finish;
    public GameObject failed;
    public bool isFinished;

    public bool isWin;
    public bool isFailed;

    public GameObject patientCounter;
    public int patientNum;

    public float goal;

    public int nextLevel;

    public int coinCount;
    public int currCoin;

    // Start is called before the first frame update
    void Start()
    {
        currCoin = PlayerPrefs.GetInt("coin");
        nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        ResumeGame();
        timerCountdown = true;
    }

    // Update is called once per frame
    void Update()
    {
        goalText.text = "Goal : " + goal.ToString();
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


        //conditional win
        if (timerFix >= 0 && patientCounter.GetComponent<counter>().nums >= goal)
        {
            finish.SetActive(true);
            patientNum = patientCounter.GetComponent<counter>().nums;
            coinCount = currCoin + patientNum;
            PlayerPrefs.SetInt("coin", coinCount);
            if (nextLevel > PlayerPrefs.GetInt("currLevel"))
            {
                PlayerPrefs.SetInt("currLevel", nextLevel);
            }

            PauseGame();
        }

        //win lose condition
        if (timerFix <= 0f)
        {
            timerFix = 0;
            
            //win
            if (patientCounter.GetComponent<counter>().nums >= goal)
            {
                finish.SetActive(true);
                patientNum = patientCounter.GetComponent<counter>().nums;
                coinCount = currCoin + patientNum;
                PlayerPrefs.SetInt("coin", coinCount);
                if (nextLevel > PlayerPrefs.GetInt("currLevel"))
                {
                    PlayerPrefs.SetInt("currLevel", nextLevel);
                }

                PauseGame();
            }else if (patientCounter.GetComponent<counter>().nums <= goal)
            {
                //Debug.Log("KALAH");
                patientNum = patientCounter.GetComponent<counter>().nums;
                coinCount = currCoin + patientNum;
                PlayerPrefs.SetInt("coin", coinCount);
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
