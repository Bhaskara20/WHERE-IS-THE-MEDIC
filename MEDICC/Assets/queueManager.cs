using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class queueManager : MonoBehaviour
{

    public GameObject AI;

    public GameObject point1;
    public GameObject point2;
    public GameObject point3;
    public GameObject point4;
    public GameObject point5;

    // Start is called before the first frame update
    void Start()
    {
        //AI = GameObject.FindWithTag("onqueue");
        ////AI = GameObject.FindWithTag("Patient");
        //AI.GetComponent<PatientAI>().option3();
    }

    // Update is called once per frame
    void Update()
    {
        
        //AI = GameObject.FindWithTag("Patient");
        
        if (point1.GetComponent<point1>().isOccupied == false)
         {
             AI = GameObject.FindWithTag("onqueue");
             AI.GetComponent<PatientAI>().option1();
         }
         else if (point1.GetComponent<point1>().isOccupied == true && point1.GetComponent<point1>().isReady == false && point2.GetComponent<point2>().isReady == true)
         {
             AI = GameObject.FindWithTag("onqueue");
             AI.GetComponent<PatientAI>().option2();
         }else if (point2.GetComponent<point2>().isOccupied == true && point2.GetComponent<point2>().isReady == false)
         {
             AI = GameObject.FindWithTag("onqueue");
             AI.GetComponent<PatientAI>().option3();
         }

    }
}
