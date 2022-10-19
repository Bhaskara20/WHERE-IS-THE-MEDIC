using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PCR : MonoBehaviour
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
            timeManagement.GetComponent<PcrTimer>().enabled = true;
            //holdit();
            pcrTest();
            

        }



    }

    void pcrTest()
    {
        Debug.Log("Sedang dilakukan test PCR");
        player.transform.position = telePoint.position;

        
        //player.transform.rotation = telePoint.rotation;

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
