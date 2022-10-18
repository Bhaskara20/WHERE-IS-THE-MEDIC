using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bloodTest : MonoBehaviour
{
    public bool isReady;

    // Update is called once per frame
    void Update()
    {
        if (isReady && Input.GetKeyUp("space"))
        {
            //holdit();
            blooodTest();

        }
    }
    void blooodTest()
    {
        Debug.Log("Sedang dilakukan test darah");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bloodLab")
        {
            isReady = true;


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "bloodLab")
        {
            isReady = false;
            //Debug.Log("Sedang dilakukan test Rontgen");
        }
    }
}
