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

    public GameObject couldron;
    public AudioSource potionFillbottle;
    public AudioSource bottleClank;

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
            potionFillbottle.Play();
            blueBottle.SetActive(true);
            couldron.GetComponent<couldron>().emptySyrup();
            couldron.GetComponent<couldron>().isBlueBoiled = false;
            couldron.GetComponent<couldron>().isRedBoiled = false;
            couldron.GetComponent<couldron>().red = false;
            couldron.GetComponent<couldron>().blue = false;
            isBlueSyrup = false;

        }

        if (isRedSyrup && Input.GetKeyUp("space"))
        {
            Debug.Log("The bottle filled with Red Syrup");
            potionFillbottle.Play();
            redBottle.SetActive(true);
            couldron.GetComponent<couldron>().emptySyrup();
            couldron.GetComponent<couldron>().isBlueBoiled = false;
            couldron.GetComponent<couldron>().isRedBoiled = false;
            couldron.GetComponent<couldron>().red = false;
            couldron.GetComponent<couldron>().blue = false;
            isRedSyrup = false;
        }

        if (isYellowSyrup && Input.GetKeyUp("space"))
        {
            Debug.Log("The bottle filled with Yellow Syrup");
            potionFillbottle.Play();
            yellowBottle.SetActive(true);
            couldron.GetComponent<couldron>().emptySyrup();
            couldron.GetComponent<couldron>().isBlueBoiled = false;
            couldron.GetComponent<couldron>().isRedBoiled = false;
            couldron.GetComponent<couldron>().red = false;
            couldron.GetComponent<couldron>().blue = false;
            isYellowSyrup = false;
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
