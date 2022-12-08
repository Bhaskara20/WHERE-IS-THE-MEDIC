using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drinkRed : MonoBehaviour
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
            Debug.Log("PASIEN MINUM OBAT MERAH");

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "redBottle")
        {
            isReady = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "redBottle")
        {
            isReady = false;
        }
    }
}
