using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class drinkBlue : MonoBehaviour
{
    public bool isReady;
    public GameObject blueBottle;
    public GameObject bottle;
    public Transform bottlePort;
    public GameObject patientSpawner;

    //public TextMeshProUGUI patientCount;
    public GameObject counter;

    // Start is called before the first frame update
    void Start()
    {
       
        //blueBottle = GameObject.FindWithTag("blueBottle");
    }

    public void referenceVariable()
    {
        if (gameObject.tag.Equals("Patient"))
        {
            patientSpawner = GameObject.FindWithTag("patientSpawner");
            //Debug.Log("i am 1");
        }else if (gameObject.tag.Equals("patient2"))
        {
            patientSpawner = GameObject.FindWithTag("patientSpawner2");
            //Debug.Log("i am 2");
        }
        else if (gameObject.tag.Equals("patient3"))
        {
            patientSpawner = GameObject.FindWithTag("patientSpawner3");
            //Debug.Log("i am 3");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        referenceVariable();
        //patientSpawner = GameObject.FindWithTag("patientSpawner");
        bottlePort = GameObject.FindWithTag("bottlePort").transform;
        bottle = GameObject.FindWithTag("bottle");
        blueBottle = GameObject.FindWithTag("blueBottle");
        counter = GameObject.FindWithTag("counter");
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

            counter.GetComponent<counter>().addCount();
            Debug.Log("Pasien Sembuh");
            gameObject.SetActive(false);


            //StartCoroutine(delaySpawn());
            patientSpawner.GetComponent<patientSpawner>().spawnPatient();


        }
    }

    private IEnumerator delaySpawn()
    {
        yield return new WaitForSeconds(5);
        patientSpawner.GetComponent<patientSpawner>().spawnPatient();
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
