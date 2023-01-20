using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pcrDelayUi : MonoBehaviour
{

    public GameObject delayUI;
    public AudioSource pcrBeep;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void turnON()
    {
        delayUI.SetActive(true);
        pcrBeep.Play();
    }

    public void turnOFF()
    {
        delayUI.SetActive(false);
        pcrBeep.Stop();
    }
}
