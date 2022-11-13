using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class pickPatient : MonoBehaviour
{
    public BoxCollider patient;
    //public BoxCollider bed;

    public Transform carry;
    public bool inReach;
    public GameObject reach;
    public GameObject text;

    public GameObject bed;
    public bool mustDrop;

    public bool isCarried;
    public Transform sleepPos;
    // Start is called before the first frame update
    void Start()
    {
        patient = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inReach && Input.GetKeyUp("space"))
        {
            thinmode();
            carryit();

        }

        if (mustDrop && Input.GetKeyUp("space"))
        {
            dropIt();
            normalMode();
            this.enabled = false;
        }
    }

    void thinmode()
    {
        patient.size = new Vector3(1f, 1f, 2.87f);
    }

    void normalMode()
    {
        patient.size = new Vector3(2.877758f, 4.344532f, 1.972594f);
    }

    private void carryit()
    {
        //GetComponent<Rigidbody>().useGravity = false;
        //GetComponent<Rigidbody>().drag = 50;
        //GetComponent<Rigidbody>().isKinematic = false;
        this.transform.position = carry.position;
        this.transform.rotation = carry.rotation;
        this.transform.parent = GameObject.Find("patientCarry").transform;
        text.SetActive(false);

        isCarried = true;
        //reach.SetActive(false);

    }

    public void dropIt()
    {
        Debug.Log("dropIt func called");
        this.transform.parent = null;
        this.transform.position = sleepPos.position;
        this.transform.rotation = sleepPos.rotation;
        isCarried = false;
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            //openText.SetActive(true);
        }

        if (other.gameObject.tag == "bed")
        {
            if (isCarried == true)
            {
                mustDrop = true;
            }else if(isCarried == false)
            {
                mustDrop = false;
            }
            
        }

        /*if (other.gameObject.tag == "Patient")
        {
            if (Input.GetKeyUp("space"))
            {
                gameObject.SetActive(false);
            }
            
            
        }*/
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            //openText.SetActive(false);
        }

        if (other.gameObject.tag == "bed")
        {
            mustDrop = false;
        }
    }
}
