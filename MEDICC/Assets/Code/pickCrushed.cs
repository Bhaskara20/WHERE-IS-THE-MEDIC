using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickCrushed : MonoBehaviour
{
    public Transform holder;
    public bool inReach;
    public GameObject reach;

    // Start is called before the first frame update
    void Start()
    {
        holder = GameObject.Find("holder").transform;
        reach = GameObject.FindWithTag("Reach");
    }

    // Update is called once per frame
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
        inReach = false;
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
