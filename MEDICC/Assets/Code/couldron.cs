using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class couldron : MonoBehaviour
{
    public bool red;
    public bool blue;
    public bool isRedBoiled;
    public bool isBlueBoiled;

    public bool isRedReady;
    public bool isBlueReady;

    public Transform redPort;
    public Transform bluePort;

    public GameObject redPutted;
    public GameObject bluePutted;

    public GameObject redPowder;
    public GameObject bluePowder;


    public GameObject redSyrup;
    public GameObject blueSyrup;
    public GameObject yellowSyrup;

    // Start is called before the first frame update
    void Start()
    {
        redPowder = GameObject.FindWithTag("redPowder");
        bluePowder = GameObject.FindWithTag("bluePowder");
    }

    // Update is called once per frame
    void Update()
    {
        if (isRedReady && Input.GetKeyUp("space"))
        {
            //Debug.Log("Red Ingridient is on mortar!");
            //redPutted.SetActive(true);
            //redIngridient.GetComponent<pickIngridient>().dropIt();
            //redIngridient.transform.position = redPort.position;
            //redIngridient.transform.rotation = redPort.rotation;
            
            //redPowder.GetComponent<pickCrushed>().dropp();
            
            red = true;
            //StartCoroutine(crushing());
            
            StartCoroutine(boil());
            isRedReady = false;
        }

        if (isBlueReady && Input.GetKeyUp("space"))
        {
            //Debug.Log("Blue Ingridient is on mortar!");
            //bluePutted.SetActive(true);
            //blueIngridient.GetComponent<pickIngridient>().dropIt();
            //blueIngridient.transform.position = bluePort.position;
            //blueIngridient.transform.rotation = bluePort.rotation;
            blue = true;
            //StartCoroutine(crushing());
            StartCoroutine(boil());
            isBlueReady = false;
        }
    }

    private IEnumerator boil()
    {
        //Debug.Log("Crushing the ingridient....");
        //yield return new WaitForSeconds(3);
        //if (red == true)
        //{
        //    Debug.Log("red ingridient was crushed!");
        //    redPutted.SetActive(false);
        //    Instantiate(crushedRed, crushedSpawner.transform.position, Quaternion.identity);
        //}
        //else if (blue == true)
        //{
        //    Debug.Log("blue ingridient was crushed!");
        //    bluePutted.SetActive(false);
        //    Instantiate(crushedBlue, crushedSpawner.transform.position, Quaternion.identity);
        //}
        Debug.Log("Boiling the powder....");
        yield return new WaitForSeconds(3);

        if (red == true)
        {
         
            Debug.Log("Red Powder was boiled!");
            isRedBoiled = true;
            redSyrup.SetActive(true);
            blueSyrup.SetActive(false);

        }
        
        if (blue == true)
        {
            
            Debug.Log("Blue Powder was boiled!");
            isBlueBoiled = true;
            redSyrup.SetActive(false);
            blueSyrup.SetActive(true);
        }

        if (isRedBoiled == true && isBlueBoiled == true)
        {
            //Debug.Log("the yellow medicine has been concocted");
            redSyrup.SetActive(false);
            blueSyrup.SetActive(false);
            //yellowSyrup.SetActive(true);
            StartCoroutine(combined());
            red = false;
            blue = false;
        }
        
        
        //if (isBlueBoiled == true && isRedBoiled == true)
        //{
        //    //Debug.Log("the yellow medicine has been concocted");
        //    //redSyrup.SetActive(false);
        //    //blueSyrup.SetActive(false);
        //    //yellowSyrup.SetActive(true);

        //    //red = false;
        //    //blue = false;
        //}

        


    }

    public void emptySyrup()
    {
        redSyrup.SetActive(false);
        blueSyrup.SetActive(false);
        yellowSyrup.SetActive(false);
    }

    private IEnumerator combined()
    {
        Debug.Log("Mixing the syrup....");
        yield return new WaitForSeconds(3);
        Debug.Log("the yellow medicine has been concocted");
        redSyrup.SetActive(false);
        blueSyrup.SetActive(false);
        yellowSyrup.SetActive(true);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "redPowder")
        {
            isRedReady = true;

        }

        if (other.gameObject.tag == "bluePowder")
        {
            isBlueReady = true;

        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "redPowder")
        {
            isRedReady = false;

        }

        if (other.gameObject.tag == "bluePowder")
        {
            isBlueReady = false;
        }

    }
}
