using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class occupy : MonoBehaviour
{
    public GameObject patient;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnPatient()
    {
        Instantiate(patient, gameObject.transform.position, Quaternion.identity);
    }
}
