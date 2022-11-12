using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bed : MonoBehaviour
{
    public GameObject patient;
    public pickPatient patientScript;
    public bool carried;
    // Start is called before the first frame update
    void Start()
    {
        carried = patientScript.isCarried;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Patient")
        {
            
            if(carried == true)
            {
                patient.GetComponent<pickPatient>().dropIt();
            }
            
        }
    }
}
