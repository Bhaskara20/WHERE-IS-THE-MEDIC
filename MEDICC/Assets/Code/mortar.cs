using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mortar : MonoBehaviour
{
    public bool red;
    public bool blue;

    public bool isRedReady;
    public bool isBlueReady;

    public Transform redPort;
    public Transform bluePort;

    public GameObject redPutted;
    public GameObject bluePutted;

    public GameObject redIngridient;
    public GameObject blueIngridient;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isRedReady && Input.GetKeyUp("space"))
        {
            Debug.Log("Red Ingridient is on mortar!");
            redPutted.SetActive(true);
            redIngridient.GetComponent<pickIngridient>().dropIt();
            redIngridient.transform.position = redPort.position;
            redIngridient.transform.rotation = redPort.rotation;

        }

        if(isBlueReady && Input.GetKeyUp("space"))
        {
            Debug.Log("Blue Ingridient is on mortar!");
            bluePutted.SetActive(true);
            blueIngridient.GetComponent<pickIngridient>().dropIt();
            blueIngridient.transform.position = bluePort.position;
            blueIngridient.transform.rotation = bluePort.rotation;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "red")
        {
            isRedReady = true;
            

        }

        if (other.gameObject.tag == "blue")
        {
            isBlueReady = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "red")
        {
            isRedReady = false;


        }

        if (other.gameObject.tag == "blue")
        {
            isBlueReady = false;
        }

    }


}
