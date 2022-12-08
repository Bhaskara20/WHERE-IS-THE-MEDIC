using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fillBottle : MonoBehaviour
{
    public bool isBlueSyrup;
    public bool isRedSyrup;
    public bool isYellowSyrup;

    public GameObject blueBottle;
    public GameObject redBottle;
    public GameObject yellowBottle;
    public GameObject emptyObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isBlueSyrup && Input.GetKeyUp("space"))
        {
            Debug.Log("The bottle filled with Blue Syrup");
            blueBottle.SetActive(true);

        }

        if (isRedSyrup && Input.GetKeyUp("space"))
        {
            Debug.Log("The bottle filled with Red Syrup");
            redBottle.SetActive(true);
        }

        if (isYellowSyrup && Input.GetKeyUp("space"))
        {
            Debug.Log("The bottle filled with Yellow Syrup");
            yellowBottle.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "blueSyrup")
        {
            isBlueSyrup = true;
        }

        if(other.gameObject.tag == "redSyrup")
        {
            isRedSyrup = true;
        }

        if(other.gameObject.tag == "yellowSyrup")
        {
            isYellowSyrup = true;
        }

        
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "blueSyrup")
        {
            isBlueSyrup = false;
        }

        if (other.gameObject.tag == "redSyrup")
        {
            isRedSyrup = false;
        }

        if (other.gameObject.tag == "yellowSyrup")
        {
            isYellowSyrup = false;
        }
    }
}
