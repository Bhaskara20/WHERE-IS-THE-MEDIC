using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XrayTimer : MonoBehaviour
{
    public GameObject timerObject;
    public GameObject player;
    public Transform homePoint;

    public Slider timer;
    public float gameTime;
    public bool stopTimer;
    private float fix;
    // Start is called before the first frame update
    void Start()
    {
        stopTimer = false;
        timer.maxValue = gameTime;
        timer.value = gameTime;
    }
    // Update is called once per frame
    void Update()
    {
        timerObject.SetActive(true);
        fix += Time.deltaTime;
        float time = gameTime - fix;

        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time - minutes * 60f);

        if (time <= 0)
        {
            stopTimer = true;
            player.transform.position = homePoint.position;
            timerObject.SetActive(false);
            
            GetComponent<XrayTimer>().enabled = false;
            Debug.Log("selesai!");
        }

        if (stopTimer == false)
        {
            timer.value = time;
        }
    }
}
