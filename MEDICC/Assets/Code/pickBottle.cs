using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class pickBottle : MonoBehaviour
{
    public Transform holder;
    public bool inReach;

    public GameObject reach;

    public bool isHolding;
    public bool isHoldingAlter;
    public GameObject player;
    public AudioSource bottleClank;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        isHolding = player.GetComponent<holdingStatus>().isHolding;
        if (isHolding == false && inReach && Input.GetKeyUp("space"))
        {
            bottleClank.Play();
            holdit();
            player.GetComponent<holdingStatus>().isHolding = true;
            isHoldingAlter = true;

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
        isHoldingAlter = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            //openText.SetActive(true);
        }

        //if (other.gameObject.tag == "couldron")
        //{
        //    isReady4boil = true;

        //}
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
