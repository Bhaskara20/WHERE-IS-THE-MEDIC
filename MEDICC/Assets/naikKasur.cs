using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class naikKasur : MonoBehaviour
{
    public Transform sleepPos;
    public GameObject patient;
    public bool naik;
    //public GameObject sleepposs;
    
    // Start is called before the first frame update
    void Start()
    {
        sleepPos = GameObject.FindWithTag("sleepPos").transform;
        patient = GameObject.FindWithTag("Patient");
        //sleepposs = GameObject.FindWithTag("sleepPos");
    }

    // Update is called once per frame
    void Update()
    {
        if (naik)
        {
            this.transform.position = sleepPos.position;
            this.transform.rotation = sleepPos.rotation;
        }
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "bed")
        {
            Debug.Log("Seharusnya naik");
            naik = true;
            //this.transform.position = sleepPos.position;
            //this.transform.rotation = sleepPos.rotation;
            //sleepposs.GetComponent<occupy>().spawnPatient();
            //patient.SetActive(true);
           // gameObject.SetActive(false);
            //this.transform.parent = null;
            
            //gameObject.GetComponent<pickPatient>().dropIt();
        }
    }
}
