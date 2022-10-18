using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class XRAY : MonoBehaviour
{
    public bool isReady;


    // Update is called once per frame
    void Update()
    {
        if (isReady && Input.GetKeyUp("space"))
        {
            //holdit();
            xrayTest();

        }
    }

    void xrayTest()
    {
        Debug.Log("Sedang dilakukan test Rontgen");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "x-ray")
        {
            isReady = true;
            //Debug.Log("Sedang dilakukan test Rontgen");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "x-ray")
        {
            isReady = false;
            //Debug.Log("Sedang dilakukan test Rontgen");
        }
    }
}
