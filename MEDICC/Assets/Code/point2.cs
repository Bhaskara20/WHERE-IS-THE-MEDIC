using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class point2 : MonoBehaviour
{
    public bool isOccupied;
    public bool isReady;
    // Start is called before the first frame update
    void Start()
    {
        isOccupied = false;
        isReady = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "onqueue")
        {
            other.tag = "Patient";
            isOccupied = true;
            isReady = false;
        }
    }
}
