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

    public void option2()
    {
        target = GameObject.FindWithTag("bed2").transform;
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = target.position;
    }
    public void option3()
    {
        target = GameObject.FindWithTag("bed3").transform;
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = target.position;
    }



    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag.Equals("Patient"))
        {
            option1();
        }else if (gameObject.tag.Equals("patient2"))
        {
            option2();
        }else if (gameObject.tag.Equals("patient3"))
        {
            option3();
        }
        
        //NavMeshAgent agent = GetComponent<NavMeshAgent>();
        //agent.destination = target.position;
    }
}
