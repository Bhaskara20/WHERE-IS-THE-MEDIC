using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class pickPatient : MonoBehaviour
{
    public Transform carry;
    public bool inReach;
    public GameObject reach;
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inReach && Input.GetKeyUp("space"))
        {
            carryit();

        }
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
        //reach.SetActive(false);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            //openText.SetActive(true);
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
    }
}
