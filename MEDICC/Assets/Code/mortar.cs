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

    public GameObject crushedRed;
    public GameObject crushedBlue;

    public GameObject crushedSpawner;

    public float crushingTime;

    
    // Start is called before the first frame update
    void Start()
    {
        crushingTime = PlayerPrefs.GetFloat("PlayerPharmacys"); ;
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
            red = true;
            StartCoroutine(crushing());
        }

        if(isBlueReady && Input.GetKeyUp("space"))
        {
            Debug.Log("Blue Ingridient is on mortar!");
            bluePutted.SetActive(true);
            blueIngridient.GetComponent<pickIngridient>().dropIt();
            blueIngridient.transform.position = bluePort.position;
            blueIngridient.transform.rotation = bluePort.rotation;
            blue = true;
            StartCoroutine(crushing());
        }

       
    }

    private IEnumerator crushing()
    {
        Debug.Log("Crushing the ingridient....");
        yield return new WaitForSeconds(crushingTime);
        if (red == true)
        {
            Debug.Log("red ingridient was crushed!");
            redPutted.SetActive(false);
            Instantiate(crushedRed, crushedSpawner.transform.position, Quaternion.identity);
        }else if (blue == true)
        {
            Debug.Log("blue ingridient was crushed!");
            bluePutted.SetActive(false);
            Instantiate(crushedBlue, crushedSpawner.transform.position, Quaternion.identity);
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
