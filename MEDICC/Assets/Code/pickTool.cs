using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickTool : MonoBehaviour
{
    public Transform holder;
    public bool inReach;
    public GameObject reach;

    void Update()
    {
        if (inReach && Input.GetKeyUp("space"))
        {
            holdit();

        }
        
    }

    private void holdit()
    {
        //GetComponent<Rigidbody>().useGravity = false;
        //GetComponent<Rigidbody>().drag = 50;
        //GetComponent<Rigidbody>().isKinematic = false;
        this.transform.position = holder.position;
        this.transform.parent = GameObject.Find("holder").transform;
        //reach.SetActive(false);
        
    }
    public void dropIt()
    {
        this.transform.parent = null;
        //GetComponent<Rigidbody>().useGravity = true;
        //GetComponent<Rigidbody>().drag = 0;
        //GetComponent<Rigidbody>().isKinematic = false;
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
