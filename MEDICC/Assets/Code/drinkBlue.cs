using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class drinkBlue : MonoBehaviour
{
    public bool isReady;
    public GameObject blueBottle;
    public GameObject bottle;
    public Transform bottlePort;
    public GameObject patientSpawner;

    // Start is called before the first frame update
    void Start()
    {
        blueBottle = GameObject.FindWithTag("blueBottle");
    }

    // Update is called once per frame
    void Update()
    {
        if (isReady && Input.GetKeyUp("space"))
        {
            //holdit();
            Debug.Log("PASIEN MINUM OBAT BIRU");
            blueBottle.SetActive(false);
            bottle.GetComponent<pickBottle>().dropIt();
            //redIngridient.transform.position = redPort.position;
            //redIngridient.transform.rotation = redPort.rotation;

            bottle.transform.position = bottlePort.position;
            bottle.transform.rotation = bottlePort.rotation;

            Debug.Log("Pasien Sembuh");
            gameObject.SetActive(false);

            patientSpawner.GetComponent<patientSpawner>().spawnPatient();


        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "blueBottle")
        {
            isReady = true;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "blueBottle")
        {
            isReady = false;
        }
    }
}
