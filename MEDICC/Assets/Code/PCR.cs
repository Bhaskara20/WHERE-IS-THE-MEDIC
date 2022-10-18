using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCR : MonoBehaviour
{
    public bool isReady;

    // Update is called once per frame
    void Update()
    {
        if (isReady && Input.GetKeyUp("space"))
        {
            //holdit();
            pcrTest();

        }
    }

    void pcrTest()
    {
        Debug.Log("Sedang dilakukan test PCR");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "pcrLab")
        {
            isReady = true;


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "pcrLab")
        {
            isReady = false;
            //Debug.Log("Sedang dilakukan test Rontgen");
        }
    }
}
