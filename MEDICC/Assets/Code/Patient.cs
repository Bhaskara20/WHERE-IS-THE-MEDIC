using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient : MonoBehaviour
{
    public GameObject holder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "tensimeter")
        {
            Debug.Log("Ukur Tensi");
        }else if (other.gameObject.tag == "thermometer")
        {
            Debug.Log("Ukur Suhu");
        }else if (other.gameObject.tag == "stetoscope")
        {
            Debug.Log("Periksa Fisik");
        }
    }
}
