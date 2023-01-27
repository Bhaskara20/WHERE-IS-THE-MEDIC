using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.WSA;

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

    public GameObject player;
    public bool isHolding;
    // Start is called before the first frame update
    void Start()
    {
        patient = GetComponent<BoxCollider>();
        carry = GameObject.FindWithTag("carry").transform;
        referenceVariable();
        //sleepPos = GameObject.FindWithTag("sleepPos").transform;
        player = GameObject.FindWithTag("Player");
        //text =
        //bed = 
    }

    public void referenceVariable()
    {
        if (gameObject.tag.Equals("Patient"))
        {
            sleepPos = GameObject.FindWithTag("sleepPos").transform;
            //patient = GameObject.FindWithTag("Patient");
        }
        else if (gameObject.tag.Equals("patient2"))
        {
            sleepPos = GameObject.FindWithTag("sleepPos2").transform;
            //patient = GameObject.FindWithTag("patient2");
        }
        else if (gameObject.tag.Equals("patient3"))
        {
            sleepPos = GameObject.FindWithTag("sleepPos3").transform;
            //patient = GameObject.FindWithTag("patient3");
        }
    }

    // Update is called once per frame
    void Update()
    {
        isHolding = player.GetComponent<holdingStatus>().isHolding;
        if (isHolding == false && inReach && Input.GetKeyUp("space"))
        {
            thinmode();
            carryit();
            player.GetComponent<holdingStatus>().isHolding = true;

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
        this.GetComponent<naikKasur>().juruSelamat();
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
        player.GetComponent<holdingStatus>().isHolding = false;
        text.SetActive(true);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            //openText.SetActive(true);
        }

        if (other.gameObject.tag == "bed" && gameObject.tag.Equals("Patient"))
        {
            if (isCarried == true)
            {
                mustDrop = true;
            }else if(isCarried == false)
            {
                mustDrop = false;
            }
            
        }else if (other.gameObject.tag == "bed2" && gameObject.tag.Equals("patient2"))
        {
            if (isCarried == true)
            {
                mustDrop = true;
            }
            else if (isCarried == false)
            {
                mustDrop = false;
            }
        }else if (other.gameObject.tag == "bed3" && gameObject.tag.Equals("patient3"))
        {
            if (isCarried == true)
            {
                mustDrop = true;
            }
            else if (isCarried == false)
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
        }else if (other.gameObject.tag == "bed2" && gameObject.tag.Equals("patient2"))
        {
            mustDrop = false;
        }
        else if (other.gameObject.tag == "bed3" && gameObject.tag.Equals("patient3"))
        {
            mustDrop = false;
        }
    }
}
