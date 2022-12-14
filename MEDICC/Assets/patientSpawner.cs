using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patientSpawner : MonoBehaviour
{
    public GameObject patient;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(patient, gameObject.transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        //Instantiate(patient, gameObject.transform.position, Quaternion.identity);
    }

    public void spawnPatient()
    {
        Instantiate(patient, gameObject.transform.position, Quaternion.identity);
    }
}
