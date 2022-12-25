using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickIngridient : MonoBehaviour
{
    public Transform holder;
    public bool inReach;
    public GameObject reach;
    public Transform redPort;
    public Transform bluePort;

    public bool isHolding;
    public GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        isHolding = player.GetComponent<holdingStatus>().isHolding;
        if (isHolding == false && inReach && Input.GetKeyUp("space"))
        {
            holdit();
            player.GetComponent<holdingStatus>().isHolding = true;

        }

    }

    private void holdit()
    {
        //GetComponent<Rigidbody>().useGravity = false;
        //GetComponent<Rigidbody>().drag = 50;
        //GetComponent<Rigidbody>().isKinematic = false;
        this.transform.position = holder.position;
        this.transform.parent = GameObject.Find("holder").transform;
        inReach = false;
        //reach.SetActive(false);

    }
    public void dropIt()
    {
        //Debug.Log("Drop!");
        this.transform.parent = null;
        player.GetComponent<holdingStatus>().isHolding = false;
        //this.transform.position = redPort.position;
        //this.transform.rotation = redPort.rotation;
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
