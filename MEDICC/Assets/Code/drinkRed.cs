using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drinkRed : MonoBehaviour
{
    public bool isReady;
    public GameObject redBottle;
    public GameObject bottle;
    public Transform bottlePort;

    public GameObject patientSpawner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        patientSpawner = GameObject.FindWithTag("patientSpawner");
        bottlePort = GameObject.FindWithTag("bottlePort").transform;
        bottle = GameObject.FindWithTag("bottle");
        redBottle = GameObject.FindWithTag("redBottle");
        if (isReady && Input.GetKeyUp("space"))
        {
            //holdit();
            Debug.Log("PASIEN MINUM OBAT MERAH");
            redBottle.SetActive(false);
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
        if (other.gameObject.tag == "redBottle")
        {
            isReady = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "redBottle")
        {
            isReady = false;
        }
    }
}
