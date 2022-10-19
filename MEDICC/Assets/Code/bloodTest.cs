using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bloodTest : MonoBehaviour
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
            timeManagement.GetComponent<BloodTimer>().enabled = true;
            //holdit();
            blooodTest();
            

        }
    }
    void blooodTest()
    {
        Debug.Log("Sedang dilakukan test darah");
        player.transform.position = telePoint.position;
       //player.transform.rotation = telePoint.rotation;

        
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
