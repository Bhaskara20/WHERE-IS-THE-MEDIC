using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickCrushed : MonoBehaviour
{
    public Transform holder;
    public bool inReach;

    public GameObject reach;
    public bool isReady4boil;
    //public BoxCollider powder;

    public bool isHolding;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        holder = GameObject.Find("holder").transform;
        reach = GameObject.FindWithTag("Reach");

        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        isHolding = player.GetComponent<holdingStatus>().isHolding;
        if (isHolding == false && inReach && Input.GetKeyUp("space"))
        {
           holdit();
           player.GetComponent<holdingStatus>().isHolding = true;

        }

        if(isReady4boil && Input.GetKeyUp("space"))
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
            player.GetComponent<holdingStatus>().isHolding = false;
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

    public void dropp()
    {
        Destroy(gameObject);
        player.GetComponent<holdingStatus>().isHolding = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            //openText.SetActive(true);
        }

        if(other.gameObject.tag == "couldron")
        {
            isReady4boil = true;
            
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
