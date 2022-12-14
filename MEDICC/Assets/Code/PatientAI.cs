using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class PatientAI : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        //target = GameObject.FindWithTag("chair1").transform;
        //option1();
    }

    public void option1()
    {
        target = GameObject.FindWithTag("bed").transform;
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = target.position;
    }

   

    // Update is called once per frame
    void Update()
    {
        option1();
        //NavMeshAgent agent = GetComponent<NavMeshAgent>();
        //agent.destination = target.position;
    }
}
