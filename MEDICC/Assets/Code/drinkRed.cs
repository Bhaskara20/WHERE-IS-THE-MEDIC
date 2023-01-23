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
    public GameObject counter;

    public GameObject skin;
    public GameObject potionCanvas;
    public AudioSource HEALED;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void referenceVariable()
    {
        if (gameObject.tag.Equals("Patient"))
        {
            patientSpawner = GameObject.FindWithTag("patientSpawner");
            //Debug.Log("i am 1");
        }
        else if (gameObject.tag.Equals("patient2"))
        {
            patientSpawner = GameObject.FindWithTag("patientSpawner2");
            //Debug.Log("i am 2");
        }
        else if (gameObject.tag.Equals("patient3"))
        {
            patientSpawner = GameObject.FindWithTag("patientSpawner3");
           // Debug.Log("i am 3");
        }

    }

    // Update is called once per frame
    void Update()
    {
        referenceVariable();
        //patientSpawner = GameObject.FindWithTag("patientSpawner");
        bottlePort = GameObject.FindWithTag("bottlePort").transform;
        bottle = GameObject.FindWithTag("bottle");
        redBottle = GameObject.FindWithTag("redBottle");
        counter = GameObject.FindWithTag("counter");
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

            counter.GetComponent<counter>().addCount();
            Debug.Log("Pasien Sembuh");

            StartCoroutine(delaySpawn());
            

        }
    }

    private IEnumerator delaySpawn()
    {
        gameObject.GetComponent<naikKasur>().gone = true;
        skin.SetActive(false);
        HEALED.Play();
        potionCanvas.SetActive(false);
        yield return new WaitForSeconds(20);
        gameObject.SetActive(false);
        patientSpawner.GetComponent<patientSpawner>().spawnPatient();
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
