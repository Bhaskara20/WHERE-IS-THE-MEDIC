using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class XRAY : MonoBehaviour
{
    public GameObject player;
    public Transform telePoint;
    public Transform homePoint;
    public bool isReady;

    public GameObject timeManagement;


    // Update is called once per frame
    void Update()
    {
        

        if (isReady && Input.GetKeyUp("space"))
        {
            timeManagement.GetComponent<XrayTimer>().enabled = true;
            //holdit();
            xrayTest();

            

        }
    }

    void xrayTest()
    {
        Debug.Log("Sedang dilakukan test Rontgen");
        player.transform.position = telePoint.position;
        //player.transform.rotation = telePoint.rotation;

        
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
