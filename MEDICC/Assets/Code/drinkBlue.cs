using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class drinkBlue : MonoBehaviour
{
    public bool isReady;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isReady && Input.GetKeyUp("space"))
        {
            //holdit();
            Debug.Log("PASIEN MINUM OBAT BIRU");

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "blueBottle")
        {
            isReady = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "blueBottle")
        {
            isReady = false;
        }
    }
}
