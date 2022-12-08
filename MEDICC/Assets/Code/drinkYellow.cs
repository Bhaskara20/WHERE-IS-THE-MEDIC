using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drinkYellow : MonoBehaviour
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
            Debug.Log("PASIEN MINUM OBAT KUNING");

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "yellowBottle")
        {
            isReady = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "yellowBottle")
        {
            isReady = false;
        }
    }
}
